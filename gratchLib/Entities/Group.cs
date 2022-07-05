using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gratchLib.Entities
{
    public class Group
    {
        protected List<Person> _people = new();
        protected IEnumerable<Person> activePeople => _people.AsReadOnly()
                                                            .Where(x => x.IsActive)
                                                            .OrderBy(x => x.Position);

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Person> People => _people.AsReadOnly();
        /// <summary>
        /// Readonly collection of <see cref="Person"/> with <see cref="Person.Position"/> bigger than 0 and ordered by ascending of <see cref="Person.Position"/>
        /// </summary>
        public IEnumerable<Person> ActivePeople => activePeople;

        public Calendar Calendar { get; set; }


        public Group(string name)
        {
            Name = name;
            Calendar = new Calendar();
        }

        public virtual void AddPerson(string name)
        {
            var person = new Person(name, this);
            person.Position = (ActivePeople?.Count() ?? 0) + 1;

            _people.Add(person);
        }
        public virtual void RemovePerson(Person person)
        {
            if (People.Contains(person))
            {
                _people.Remove(person);
                NormalizePositions();
            }
        }

        public virtual bool Contains(string name) => People.Any(p => p.Name == name);
        protected virtual void NormalizePositions()
        {
            // Select all people with positions in ascending order
            var activepeople = activePeople;
            // remove gaps in positions
            for (int i = 0; i < activepeople.Count(); i++)
            {
                activepeople.ElementAt(i).Position = i + 1;
            }

        }
        protected virtual void ShiftPositionsAfter(Person person)
        {
            if (person.IsActive)
            {
                List<Person> peopleToSkip = new() { person }; // Skip this <person>
                // Skip person with <person.Position>, that is not the same person
                activePeople.Where(p => p.Position == person.Position && p != person)
                            .Select(p => p.Position += 1); // Also, shift its position right
                // NOTE: <person> and peopleToSkip may be in this collection too
                var peopleAfterPerson = activePeople.SkipWhile(x => x.Position != person.Position);

                foreach (var p in peopleAfterPerson)
                {
                    if (peopleToSkip.Contains(p)) continue; // skip peopleToSkip
                    p.Position += 1; // move everyone else
                }
            }
        }

    }
}

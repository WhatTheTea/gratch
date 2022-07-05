using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gratchLib.Entities
{
    public class Group : IEnumerable<Person>
    {
        protected List<Person> _people = new();

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Person> People => _people.AsReadOnly();
        /// <summary>
        /// Readonly collection of <see cref="Person"/> with <see cref="Person.Position"/> bigger than 0 and ordered by ascending of <see cref="Person.Position"/>
        /// </summary>
        public IEnumerable<Person> ActivePeople => _people.Where(x => x.IsActive)
                                                          .OrderBy(x => x.Position);

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
            }
        }

        public virtual bool Contains(string name) => People.Any(p => p.Name == name);
        /// <summary>
        /// Makes people positions go from 1 to <see cref="ActivePeople"/>.Count()
        /// </summary>
        protected virtual void NormalizePositions()
        {
            // Select all people with positions in ascending order
            var activepeople = ActivePeople;
            // remove gaps in positions
            for (int i = 0; i < activepeople.Count(); i++)
            {
                activepeople.ElementAt(i).Position = i + 1;
            }

        }
        /// <summary>
        /// Adds 1 to all people's positions after <paramref name="person"/>
        /// </summary>
        /// <param name="person"></param>
        protected virtual void ShiftPositionsAfter(Person person)
        {
            if (person.IsActive)
            {
                List<Person> peopleToSkip = new() { person }; // Skip this <person>
                
                var overlappingPeople = ActivePeople.Where(p => p.Position == person.Position && p != person)
                                                    .Select(p =>
                                                    {
                                                        p.Position += 1;
                                                        return p;
                                                    });
                peopleToSkip.AddRange(overlappingPeople);

                // NOTE: <person> and peopleToSkip may be in this collection too
                var peopleAfterPerson = ActivePeople.SkipWhile(x => x.Position != person.Position);

                foreach (var p in peopleAfterPerson)
                {
                    if (peopleToSkip.Contains(p)) continue; // skip peopleToSkip
                    p.Position += 1; // move everyone else
                }
            }
        }

        public IEnumerator<Person> GetEnumerator() => People.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Subjects;

namespace gratchLib.Entities
{
    public class Group : IDisposable
    {
        private bool disposedValue;
        protected List<Person> _people = new();
        protected string _name;
        protected Subject<(int id, string newname)> whenNameChanged = new();

        public int Id { get; set; }
        public string Name 
        { 
            get => _name;
            set => Rename(value);
        }
        public IEnumerable<Person> People => _people;
        /// <summary>
        /// Readonly collection of <see cref="Person"/> with <see cref="Person.Position"/> bigger than 0 and ordered by ascending of <see cref="Person.Position"/>
        /// </summary>
        public IEnumerable<Person> ActivePeople => _people.Where(x => x.IsActive)
                                                          .OrderBy(x => x.Position);
        public Calendar Calendar { get; set; }
        public IObservable<(int id, string newname)> WhenNameChanged => whenNameChanged;

        public Group() => (_name, Calendar) = (string.Empty, new(this));
        public Group(string name) : this()
        {
            _name = name;
        }

        public virtual void Rename(string name)
        {
            if(name != string.Empty)
            {
                _name = name;
                whenNameChanged.OnNext((Id, Name));
            } else whenNameChanged.OnError(new ArgumentException(paramName: nameof(name), message: "Name can't be empty"));
        }

        public virtual void AddPerson(string name, bool isActive = true)
        {
            var person = new Person(name, this);
            // Assign or not position based on isActive
            person.Position = isActive ? (ActivePeople?.Count() ?? 0) + 1 : 0;
            
            _people.Add(person);
        }
        public virtual void RemovePerson(Person person) => _people.Remove(person);   
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

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    foreach(var p in _people)
                    {
                        p.Dispose();
                    }
                    whenNameChanged.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

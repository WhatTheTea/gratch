using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Subjects;

using gratchLib.Entities.Arrangement;

namespace gratchLib.Entities
{

    public class Group : IGroup, IDisposable
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
        public IEnumerable<Person> ActivePeople => _people.Where(x => x.IsArranged)
                                                          .OrderBy(x => x.Position);
        public Calendar Calendar { get; set; }
        public IObservable<(int id, string newname)> WhenNameChanged => whenNameChanged;

        public IArrangementStrategy ArrangementStrategy { get; set; }

        public Group()
        {
            (_name, Calendar) = (string.Empty, new(this));
            ArrangementStrategy = new BaseArrangementStrategy(People.Cast<IArrangeable>());
        }
        public Group(string name) : this()
        {
            _name = name;
        }

        public virtual void Rename(string name)
        {
            try
            {
                _ = string.IsNullOrWhiteSpace(name) ? throw new ArgumentException(paramName: nameof(name), message: "Value can't be string.Empty") : name;

                _name = name;
                whenNameChanged.OnNext((Id, Name));
            }
            catch (ArgumentException exception)
            {
                whenNameChanged.OnError(exception);
            }
        }

        public virtual void CreatePerson(string name)
        {
            var person = new Person(name);
            AddPerson(person);
        }

        public virtual void AddPerson(Person person)
        {
            _ = person ?? throw new ArgumentNullException(nameof(person));
            if (person.Group == this) return;
            person.Group = this;
            ArrangementStrategy.Arrange(person);
            _people.Add(person);
        }

        public virtual void RemovePerson(Person person) => _people.Remove(person);
        public virtual bool Contains(string name) => People.Any(p => p.Name == name);
#region move
        // TODO: Move to strategy
        /// <summary>
        /// Makes people positions go from 1 to <see cref="ActivePeople"/>.Count()
        /// </summary>
        public virtual void NormalizePositions()
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
        
#endregion
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    foreach (var p in _people)
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Subjects;

using gratch.Library.Arrangement;

namespace gratch.Library
{

    public class Group : IArrangeableGroup, IDisposable
    {
        private bool disposedValue;
        protected string _name;
        protected List<Person> _people = new();
        protected IArrangement arrangement;
        protected Subject<(int id, string newname)> whenNameChanged = new();

        public int Id { get; set; }
        public string Name
        {
            get => _name;
            set => Rename(value);
        }
        public IEnumerable<Person> People => _people;
        public IEnumerable<Person> ArrangedPeople => _people.Where(x => x.IsArranged)
                                                            .OrderBy(x => x.Position);
        public Calendar Calendar { get; set; }
        public IObservable<(int id, string newname)> WhenNameChanged => whenNameChanged;

        public IArrangement Arrangement 
        { 
            get => arrangement;
            set 
            {
                arrangement = value;
                arrangement.SetContext(this);
                //arrangement.ArrangeAll(EArrangementMode.Arranged);
            }
        }
        IEnumerable<IArrangeable> IArrangeableGroup.Arrangeables => People;
        IEnumerable<IArrangeable> IArrangeableGroup.Arranged => ArrangedPeople;

        public Group(string name, IArrangement? arrangement = null)
        {
            (_name, Calendar) = (name, new(this));
            this.arrangement = arrangement ?? new BaseArrangement(this);
            this.arrangement.SetContext(this);
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
            Arrangement.Arrange(person);
            _people.Add(person);
        }

        public virtual void RemovePerson(Person person) {
            Arrangement.RemoveArrangement(person);
            _people.Remove(person);
        }
            
        public virtual bool Contains(string name) => People.Any(p => p.Name == name);

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

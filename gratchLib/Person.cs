using System.Reactive.Subjects;

namespace gratchLib
{
    public abstract class Person : IDisposable, IAssignable<Schedule>
    {
        // fields
        protected string name = string.Empty;
        protected int position = 0;
        private bool disposedValue;

        protected Group group;

        private readonly Subject<Person> whenNameChanged = new();
        private readonly Subject<Person> whenPositionChanged = new();

        // properties
        public virtual Group Group => GroupReadOnly.Get(group);
        public virtual string Name { get => name; set => Rename(value); }
        public virtual int Position { get => position; internal set => position = value; }

        // observables
        public IObservable<Person> WhenNameChanged => whenNameChanged;
        public IObservable<Person> WhenPositionChanged => whenPositionChanged;

        // interface
        public virtual void AssignTo(Schedule schedule) => schedule.Assign(this); // TODO: smth better

        /* constructors
        internal Person(Group group, string name)
        {
            this.group = group;
            this.name = name;
            Position = 0;
        }
        */
        // methods
        public virtual void Rename(string newname)
        {
            if (!Group.Contains(newname))
            {
                this.name = newname;
                whenNameChanged.OnNext(this);
            }
        }
        public virtual void ChangePosition(int pos)
        {
            var isPosValid = pos >= 0 && pos <= group.ActivePeople.Count + 1;

            if (isPosValid)
            {
                this.position = pos;

                whenPositionChanged.OnNext(this);
            }
        }

        #region IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    whenNameChanged.Dispose();
                    whenPositionChanged.Dispose();
                }

                group = null;

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
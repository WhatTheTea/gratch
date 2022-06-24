using System.Reactive.Subjects;

namespace gratchLib
{
    public class Person : IDisposable, IAssignable
    {
        // fields
        private string name = string.Empty;
        private int position = 0;
        private bool disposedValue;

        private Group group;

        private readonly Subject<Person> whenNameChanged = new();
        private readonly Subject<Person> whenPositionChanged = new();

        // properties
        public IGroup Group => GroupReadOnly.Get((IGroup)group);
        public string Name { get => name; set => Rename(value); }
        public int Position { get => position; internal set => position = value; }

        // observables
        public IObservable<Person> WhenNameChanged => whenNameChanged;
        public IObservable<Person> WhenPositionChanged => whenPositionChanged;

        // interface
        public void AssignTo(ISchedule schedule) => schedule.Assign(this); // TODO: smth better

        // constructors
        internal Person(Group group, string name)
        {
            this.group = group;
            this.name = name;
            Position = 0;
        }

        // methods
        public void Rename(string newname)
        {
            if (!Group.Contains(newname))
            {
                this.name = newname;
                whenNameChanged.OnNext(this);
            }
        }
        public void ChangePosition(int pos)
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
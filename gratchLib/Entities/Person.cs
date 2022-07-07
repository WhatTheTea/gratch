using System.Reactive.Subjects;

namespace gratchLib.Entities
{
    public class Person : IDisposable
    {
        private bool disposedValue;
        protected int _position = 0;
        protected string _name = string.Empty;
        protected Subject<(int Id,string newname)> whenNameChanged = new();
        protected Subject<(int Id,int newpos)> whenPositionChanged = new();

        public int Id { get; set; }
        public string Name { get => _name; set => Rename(value); }
        public int Position { get => _position; set => ChangePosition(value); }
        public bool IsActive => Position > 0;
        public Group? Group { get; set; }
        public IObservable<(int Id,string newname)> WhenNameChanged => whenNameChanged;
        public IObservable<(int Id,int newpos)> WhenPositionChanged => whenPositionChanged;


        public Person(string name) => _name = name;
        public Person(string name, Group group) : this(name) => Group = group;

        public virtual void Rename(string name)
        {
            _name = name;
            whenNameChanged.OnNext((Id, _name));
        }
        /// <summary>
        /// Changes person's position.
        /// </summary>
        /// <param name="position"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public virtual void ChangePosition(int position)
        {
            var isPosInRange = position >= 0 && position <= Group.ActivePeople.Count() + 1;
            if(isPosInRange)
            {
                _position = position;
                whenPositionChanged.OnNext((Id, _position));
            } else 
            {
                whenPositionChanged.OnError(new ArgumentOutOfRangeException(nameof(position)));
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    whenNameChanged.Dispose();
                    whenPositionChanged.Dispose();
                }

                ///// TODO: free unmanaged resources (unmanaged objects) and override finalizer
                ///// TODO: set large fields to null
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            //// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

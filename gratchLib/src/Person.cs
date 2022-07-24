using System.Reactive.Subjects;

namespace gratch.Library
{
    public class Person : IDisposable, Arrangement.IArrangeable
    {
        private bool disposedValue;
        protected int _position = 0;
        protected string _name = string.Empty;
        protected Subject<(int Id,string newname)> whenNameChanged = new();
        protected Subject<(int Id,int newpos)> whenPositionChanged = new();

        public int Id { get; set; }
        public string Name { get => _name; set => Rename(value); }
        public int Position { get => _position; set => ChangePosition(value); }
        public bool IsArranged => Position > 0;
        public Group? Group { get; set; }
        public IObservable<(int Id,string newname)> WhenNameChanged => whenNameChanged;
        public IObservable<(int Id,int newpos)> WhenPositionChanged => whenPositionChanged;


        public Person(string name) => _name = name;
        public Person(string name, Group group) : this(name) => Group = group;

        public virtual void Rename(string name)
        {
            try
            {
                _ = string.IsNullOrWhiteSpace(name) ? throw new ArgumentException(paramName: nameof(name), message: "Value can't be string.Empty") : name;

                _name = name;
                whenNameChanged.OnNext((Id, Name));
            } 
            catch (ArgumentException ex)
            {
                whenNameChanged.OnError(ex);
            }

        }
        /// <summary>
        /// Changes person's position.
        /// </summary>
        /// <param name="position"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public virtual void ChangePosition(int position)
        {
            try
            {
                var isPosInRange = position >= 0 && position <= Group.ArrangedPeople.Count() + 1;
                _ = !isPosInRange ? throw new ArgumentOutOfRangeException(nameof(position)) : true;

                _position = position;
                whenPositionChanged.OnNext((Id, Position));
            } 
            catch (ArgumentOutOfRangeException ex)
            {
                whenPositionChanged.OnError(ex);
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

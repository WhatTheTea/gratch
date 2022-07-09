namespace gratchLib.Entities.Arrangement
{
    public class BaseArrangementStrategy : IArrangementStrategy
    {
        protected IEnumerable<IArrangeable> arrangeables;

        public BaseArrangementStrategy(IEnumerable<IArrangeable> arrangeables)
        {
            this.arrangeables = arrangeables;
        }

        public virtual void Arrange(IArrangeable arrangeable)
        {
            _ = arrangeable ?? throw new ArgumentNullException(nameof(arrangeable));
        }
        public virtual void ArrangeAt(IArrangeable arrangeable, int position)
        {
            _ = arrangeable ?? throw new ArgumentNullException(nameof(arrangeable));
        }
        public virtual void ArrangeAll(EArrangementMode mode = EArrangementMode.All)
        {

        }
    }
}
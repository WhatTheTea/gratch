namespace gratchLib.Entities.Arrangement
{
    public class BaseArrangementStrategy : IArrangementStrategy
    {
        protected IEnumerable<IArrangeable> arrangeables;
        protected IEnumerable<IArrangeable> arranged => arrangeables.Where(x => x.IsArranged)
                                                                    .OrderBy(x => x.Position);

        public BaseArrangementStrategy(IEnumerable<IArrangeable> arrangeables)
        {
            this.arrangeables = arrangeables;
        }

        public virtual void Arrange(IArrangeable arrangeable)
        {
            _ = arrangeable ?? throw new ArgumentNullException(nameof(arrangeable));
        }
        public virtual void ArrangeTo(IArrangeable arrangeable, int position)
        {
            _ = arrangeable ?? throw new ArgumentNullException(nameof(arrangeable));
        }
        public virtual void ArrangeAll(EArrangementMode mode = EArrangementMode.All)
        {

        }

        public virtual void RemoveArrangement(IArrangeable arrangeable)
        {
            _ = arrangeable ?? throw new ArgumentNullException(nameof(arrangeable));
        }
    }
}
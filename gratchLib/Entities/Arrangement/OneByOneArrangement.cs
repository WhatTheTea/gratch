namespace gratchLib.Entities.Arrangement
{
    public class OneByOneArrangement : BaseArrangement
    {
        public OneByOneArrangement() : base() { }
        public OneByOneArrangement(IArrangeableGroup context) : base(context)
        {
        }
        public override void Arrange(IArrangeable arrangeable)
        {
            base.Arrange(arrangeable);
            arrangeable.Position = (Context.Arranged?.Count() ?? 0) + 1;
        }
        public override void ArrangeTo(IArrangeable arrangeable, int position)
        {
            base.ArrangeTo(arrangeable, position);

            arrangeable.Position = position;
            ShiftPositionsAfter(arrangeable);
        }
        public override void ArrangeAll(EArrangementMode mode = EArrangementMode.All)
        {
            base.ArrangeAll();

            var arrangeablesToArrange = mode switch
                {
                    EArrangementMode.All => Context.Arrangeables,
                    EArrangementMode.Arranged => Context.Arranged,
                    _ => throw new ArgumentOutOfRangeException(nameof(mode))
                };

            for (int i = 0; i < arrangeablesToArrange.Count(); i++)
            {
                arrangeablesToArrange.ElementAt(i).Position = i + 1;
            }
        }

        public override void RemoveArrangement(IArrangeable arrangeable) 
        {
            base.RemoveArrangement(arrangeable);

            ShiftPositionsAfter(arrangeable, EDirection.Left);
            arrangeable.Position = 0;
        }

        protected void ShiftPositionsAfter(IArrangeable arrangeable, EDirection direction = EDirection.Right)
        {
            if (Context.Arranged.Contains(arrangeable))
            {
                List<IArrangeable> arrangeablesToSkip = new() { arrangeable }; // Skip this arrangeable

                var overlappingArrangeables = Context.Arranged.Where(a => a.Position == arrangeable.Position && a != arrangeable)
                                                              .Select(a => ShiftPosition(a, direction));
                arrangeablesToSkip.AddRange(overlappingArrangeables);

                // NOTE: arrangeable and arrangeablesToSkip may be in this collection too
                var arrangeablesFrom = Context.Arranged.SkipWhile(a => a.Position != arrangeable.Position);

                foreach (var a in arrangeablesFrom)
                {
                    if (arrangeablesToSkip.Contains(a)) continue; // skip
                    a.Position += 1; // move everyone else
                }
            }
        }
        /// <returns> Shifted arrangeable </returns>
        protected IArrangeable ShiftPosition(IArrangeable arrangeable, EDirection direction)
        {
            _ = direction switch
                {
                    EDirection.Right => arrangeable.Position += 1,
                    EDirection.Left => arrangeable.Position -= 1,
                    _ => throw new ArgumentOutOfRangeException(nameof(direction))
                };
            return arrangeable;
        }

        protected enum EDirection
        {
            Right,
            Left
        }
    }
}
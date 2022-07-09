namespace gratchLib.Entities.Arrangement
{
    public class OneByOneArrangementStrategy : BaseArrangementStrategy
    {
        private IEnumerable<IArrangeable> arranged => arrangeables.Where(x => x.IsArranged)
                                                                  .OrderBy(x => x.Position);
        public OneByOneArrangementStrategy(IEnumerable<IArrangeable> arrangeables) : base(arrangeables)
        {

        }
        public override void Arrange(IArrangeable arrangeable)
        {
            base.Arrange(arrangeable);
            arrangeable.Position = (arranged?.Count() ?? 0) + 1;
        }
        public override void ArrangeAt(IArrangeable arrangeable, int position)
        {
            base.ArrangeAt(arrangeable, position);

            arrangeable.Position = position;
            ShiftPositionsAfter(arrangeable);
        }
        public override void ArrangeAll(EArrangementMode mode = EArrangementMode.All)
        {
            base.ArrangeAll();

            var arrangeablesToArrange = mode switch
                {
                    EArrangementMode.All => arrangeables,
                    EArrangementMode.Arranged => arranged,
                    _ => throw new ArgumentOutOfRangeException(nameof(mode))
                };

            for (int i = 0; i < arrangeablesToArrange.Count(); i++)
            {
                arrangeablesToArrange.ElementAt(i).Position = i + 1;
            }
        }
        protected void ShiftPositionsAfter(IArrangeable arrangeable)
        {
            if (arranged.Contains(arrangeable))
            {
                List<IArrangeable> arrangeablesToSkip = new() { arrangeable }; // Skip this arrangeable

                var overlappingArrangeables = arranged.Where(a => a.Position == arrangeable.Position && a != arrangeable)
                                                .Select(p =>
                                                {
                                                    p.Position += 1;
                                                    return p;
                                                });
                arrangeablesToSkip.AddRange(overlappingArrangeables);

                // NOTE: arrangeable and arrangeablesToSkip may be in this collection too
                var arrangeablesFrom = arranged.SkipWhile(a => a.Position != arrangeable.Position);

                foreach (var a in arrangeablesFrom)
                {
                    if (arrangeablesToSkip.Contains(a)) continue; // skip
                    a.Position += 1; // move everyone else
                }
            }
        }
    }
}
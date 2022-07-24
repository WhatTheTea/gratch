using System.Collections;

namespace gratch.Library
{
    public readonly struct DateTimeRange : IEnumerable<DateTime>
    {
        private readonly List<DateTime> range = new();
        public readonly DateTime Start { get; init; }
        public readonly DateTime End { get; init; }
        public int DaysSpan => (int)Math.Round((End.Date - Start.Date).TotalDays) + 1;
        public DateTimeRange(DateTime start, DateTime end)
        {
            (Start, End) = (start, end);

            foreach (int n in Enumerable.Range(0, DaysSpan))
            {
                range.Add(start.AddDays(n).Date);
            }
        }

        public IEnumerator<DateTime> GetEnumerator() => range.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
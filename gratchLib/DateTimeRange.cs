using System.Collections;

namespace gratchLib
{
    public readonly struct DateTimeRange : IEnumerable<DateTime>
    {
        private readonly List<DateTime> range = new();
        public DateTime Start { get; }
        public DateTime End { get; }
        public int DaysSpan => (int)Math.Round((End.Date - Start.Date).TotalDays);
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
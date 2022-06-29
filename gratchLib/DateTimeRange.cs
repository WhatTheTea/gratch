using System.Collections;

namespace gratchLib
{
    public struct DateTimeRange : IEnumerable<DateTime>
    {
        private List<DateTime> range = new();
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public int DaysSpan => (int)Math.Round((End.Date - Start.Date).TotalDays);
        public DateTimeRange(DateTime start, DateTime end)
        {
            this.Start = start;
            this.End = end;

            foreach (int n in Enumerable.Range(0, DaysSpan))
            {
                range.Add(start.AddDays(n).Date);
            }
        }

        public IEnumerator<DateTime> GetEnumerator() => range.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }


}
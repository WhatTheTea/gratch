namespace gratchLib
{
    public struct DateTimeRange
    {
        public DateTime Start;
        public DateTime End;

        public DateTimeRange(DateTime start, DateTime end)
        {
            this.Start = start;
            this.End = end;
        }
    }
}
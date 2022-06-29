

namespace gratchLib
{
    public class Schedule
    {
        protected Dictionary<DateTime, Person> _schedule = new();

        public DateTimeRange Period { get; protected set; }
        public Group Group { get; protected set; }
        public Person this[DateTime date] => _schedule[date];

        public Schedule(Group group, DateTimeRange period)
        {
            this.Group = group;
            this.Period = period;
        }

        protected void BuildSchedule()
        {
            
        }
        protected int FirstPosition
        {
            get
            {
                var peoplecount = Group.People.Count;
                var startdate = Group.Calendar.StartDate;
                // period between first init and start of schedule's period;
                var period = new DateTimeRange(startdate, Period.Start);
                return ((period.DaysSpan - (Period.Start.Day-1)) % peoplecount) + 1;
            }
        }
    }
}
using System.Collections;

namespace gratchLib
{
    public class Schedule : IEnumerable<KeyValuePair<DateTime, Person>>
    {
        protected Dictionary<DateTime, Person> _schedule = new();

        public DateTimeRange Period { get; protected set; }
        public Group Group { get; protected set; }
        public Person this[DateTime date] => _schedule[date];

        public Schedule(Group group, DateTimeRange period)
        {
            this.Group = group;
            this.Period = period;
            BuildSchedule();
        }

        protected void BuildSchedule()
        {
            for (int i = 0, j = 1; i < Period.DaysSpan; i++, j++)
            {
                var dateToAssign = Period.ElementAt(i);
                if (Group.Calendar.IsHoliday(dateToAssign)) continue; // skip if holiday
                if (j > Group.ActivePeople.Count) j = 1;              // first pos on overflow
                _schedule.Add(dateToAssign, Group.ActivePeople[j]);
            }
        }
        /// <summary>
        /// Returns <see cref="Person.Position"/> for <see cref="Period"/> first date
        /// </summary>
        protected int FirstPosition
        {
            get
            {
                var peoplecount = Group.People.Count;
                var startdate = Group.Calendar.StartDate;
                var periodstart = Period.Start;
                // period between first init and start of schedule's period;
                var period = new DateTimeRange(startdate, periodstart);
                return ((period.DaysSpan - (periodstart.Day - 1)) % peoplecount) + 1;
            }
        }

        public override string ToString()
        {
            string result = string.Empty;

            foreach (KeyValuePair<DateTime, Person> pair in this)
            {
                // DD.MM.YYYY : Person [Pos]
                result += pair.Key.ToShortDateString() + " : " + pair.Value.Name + $" [{pair.Value.Position}]\n";
            }

            return result;
        }

        public IEnumerator GetEnumerator() => _schedule.GetEnumerator();
        IEnumerator<KeyValuePair<DateTime, Person>> IEnumerable<KeyValuePair<DateTime, Person>>.GetEnumerator() => _schedule.GetEnumerator();
    }
}
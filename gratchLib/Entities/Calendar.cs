namespace gratchLib.Entities
{
    public class Calendar
    {
        protected List<DayOfWeek> weekend = new();
        protected List<Holiday> holidays = new();

        public int Id { get; set; }
        public IList<Holiday> Holidays => holidays.AsReadOnly();
        public IList<DayOfWeek> Weekend => weekend.AsReadOnly();
        public DateOnly StartDate { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public virtual void AddHoliday(Holiday holiday)
        {
            holiday.Calendar = this;
            holidays.Add(holiday);
        }
        public virtual void RemoveHoliday(Holiday holiday) => holidays.Remove(holiday);
        public virtual void RemoveHolidayAt(int index) => holidays.RemoveAt(index);

        public virtual void AddDayOff(DayOfWeek day) => weekend.Add(day);
        public virtual void RemoveDayOff(DayOfWeek day) => weekend.Remove(day);

        /// <summary>Determines if date belongs to <see cref="Holidays"/> or <see cref="Weekend"/></summary>
        public virtual bool IsHoliday(DateTime date)
        {
            return Weekend.Contains(date.DayOfWeek) ||
                   Holidays.Any(day => day.IsEqual(date));
        }
    }
}

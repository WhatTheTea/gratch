namespace gratchLib
{
    public abstract class Calendar
    {
        protected List<Holiday> holidays = new();
        protected List<DayOfWeek> weekend = new();

        public virtual IList<Holiday> Holidays => holidays.AsReadOnly();
        public virtual IList<DayOfWeek> Weekend => weekend.AsReadOnly();

        public virtual void AddHoliday(Holiday holiday)
        {

        }
        public virtual void RemoveHoliday(Holiday holiday)
        {

        }
        public virtual void RemoveHoliday(int index)
        {

        }
    }
}
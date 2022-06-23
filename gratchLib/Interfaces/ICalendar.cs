namespace gratchLib
{
    public interface ICalendar
    {
        IList<IHoliday> Holidays { get; }
        IList<DayOfWeek> Weekend { get; }

        void AddHoliday(IHoliday holiday);
        void RemoveHoliday(IHoliday holiday);
        void AddDayOff(DayOfWeek dayOfWeek);
        void RemoveDayOff(DayOfWeek dayOfWeek);
    }
}
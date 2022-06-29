namespace gratchLib
{
    public interface ICalendar
    {
        IList<Holiday> Holidays { get; }
        DateTime StartDate { get; }
        IList<DayOfWeek> Weekend { get; }
    }
}
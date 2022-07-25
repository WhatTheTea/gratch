namespace gratch.Api.Data
{
    public record CalendarModel(
        int Id,
        int GroupId,
        List<DayOfWeek> Weekend,
        List<HolidayModel> Holidays,
        DateTime StartDate  
        );
}
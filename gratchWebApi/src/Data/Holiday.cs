namespace gratch.Api.Data
{
    public record HolidayModel(
        int Id,
        int Name,
        int CalendarId,
        CalendarModel Calendar,
        DateTime Date  
        );
}
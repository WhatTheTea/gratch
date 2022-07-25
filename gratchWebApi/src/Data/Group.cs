namespace gratch.Api.Data
{
    public record GroupModel(
        int Id,
        int CalendarId,
        CalendarModel Calendar,
        List<PersonModel> People,
        string Name,
        string Arrangement
        );
}
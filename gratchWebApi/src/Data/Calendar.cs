namespace gratch.Api.Data
{
    public class CalendarModel
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public List<DayOfWeek>? Weekend { get; set; } = new();
        public List<HolidayModel>? Holidays { get; set; } = new();
        public DateTime StartDate { get; set; } 
    }
}
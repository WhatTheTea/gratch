namespace gratch.Api.Data
{
    public class HolidayModel
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int CalendarId { get; set; }
        public CalendarModel? Calendar { get; set; }
        public DateTime Date { get; set; }
    }
}
namespace gratch.Api.Data
{
    public class GroupModel
    {
        public int Id { get; set; }
        public CalendarModel Calendar { get; set; } = new();
        public List<PersonModel>? People { get; set; } = new();
        public string Name { get; set; }
        public string Arrangement { get; set; }
    }
}
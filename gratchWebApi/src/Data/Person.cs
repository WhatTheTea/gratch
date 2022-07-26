namespace gratch.Api.Data
{
    public class PersonModel
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public GroupModel? Group { get; set; }
        public int Position { get; set; }
    }
}
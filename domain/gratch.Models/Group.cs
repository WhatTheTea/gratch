namespace gratch.Models;

public class Group
{
    public required string Id { get; set; }

    public required string Name { get; set; }

    public required DateTimeOffset BaseDateTimeOffset { get; set; }

    public List<Person> People { get; set; } = [];

    public ArrangementConfiguration ArrangementConfiguration { get; set; } = new();
}

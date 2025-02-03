namespace gratch.Models;

public class Group : List<Person>
{
    public string Name { get; set; } = string.Empty;

    public DateTimeOffset BaseDateTimeOffset { get; set; }

    public ArrangementConfiguration ArrangementConfiguration { get; set; } = new();
}

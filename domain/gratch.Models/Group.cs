using System.Diagnostics.CodeAnalysis;

namespace gratch.Models;

public class Group
{
    public required string Id { get; set; }

    public required string Name { get; set; }

    public required DateTimeOffset BaseDateTimeOffset { get; set; }

    public List<Person> People { get; set; } = [];

    public ArrangementConfiguration ArrangementConfiguration { get; set; } = new();

    public Group() { }

    [SetsRequiredMembers]
    public Group(string name, DateTimeOffset baseArrangementOffset = default)
    {
        this.Id = Guid.NewGuid().ToString();
        this.Name = name;
        this.BaseDateTimeOffset = baseArrangementOffset == default ? DateTimeOffset.Now : baseArrangementOffset;
    }

    public static class Validate
    {
        public static bool Name(string name) => !string.IsNullOrEmpty(name);
    }
}

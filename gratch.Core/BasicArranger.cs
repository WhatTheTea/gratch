using WhatTheTea.Gratch.Models;

namespace WhatTheTea.Gratch.Core;

public class BasicArranger : IArranger
{
    public const ArrangementKind Kind = ArrangementKind.Basic;

    /// <summary>
    /// Creates new arrangement from people collection without title
    /// </summary>
    /// <returns>
    /// One by one arrangement of people
    /// </returns>
    public Arrangement ArrangeMany(IEnumerable<Person> people) => new()
    {
        Kind = Kind,
        PeopleArrangement = GenerateArrangement(people)
    };

    public Dictionary<DateTimeOffset, Person[]> GenerateTimeArrangement(Arrangement arrangement,
                                                                        DateTimeOffset start,
                                                                        DateTimeOffset end)
    {
        var result = new Dictionary<DateTimeOffset, Person[]>();
        var daysInTicks = end.Ticks - start.Ticks;
        int daysCount = (int)(daysInTicks / TimeSpan.TicksPerDay);

        return Enumerable.Range(0, daysCount)
                         .Select(x => start.AddDays(x)) // Get days from start to end
                         .Chunk(arrangement.PeopleArrangement.Count) // For each day assign person/people
                         .SelectMany(days =>
                            days.Select((day, i) =>
                                KeyValuePair.Create(day, arrangement.PeopleArrangement[i])
                            )
                         ).ToDictionary();
    }
    private static Dictionary<int, Person[]> GenerateArrangement(IEnumerable<Person> people) =>
        people.Select((person, i) => KeyValuePair.Create(i, new Person[] { person }))
              .ToDictionary();
}

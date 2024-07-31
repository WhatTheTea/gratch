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
                                                                        DateTimeOffset end) => throw new NotImplementedException();
    private static Dictionary<int, Person[]> GenerateArrangement(IEnumerable<Person> people) =>
        people.Select((person, i) => KeyValuePair.Create(i, new Person[] { person }))
              .ToDictionary();
}

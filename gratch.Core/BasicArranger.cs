using WhatTheTea.Gratch.Models;

namespace WhatTheTea.Gratch.Core;

public class BasicArranger(TimeProvider timeProvider) : IArranger
{
    public const ArrangementKind Kind = ArrangementKind.Basic;

    /// <summary>
    ///     
    /// </summary>
    /// <param name="people"></param>
    /// <returns></returns>
    public Arrangement ArrangeMany(IEnumerable<Person> people) => throw new NotImplementedException();
    public Dictionary<DateTimeOffset, Person> GenerateTimeArrangement(Arrangement arrangement) => throw new NotImplementedException();
}

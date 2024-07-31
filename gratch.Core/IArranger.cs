using WhatTheTea.Gratch.Models;

namespace WhatTheTea.Gratch.Core;

/// <summary>
/// Provides mechanism to assign
/// </summary>
public interface IArranger
{
    Arrangement ArrangeMany(IEnumerable<Person> people);
    Dictionary<DateTimeOffset, Person[]> GenerateTimeArrangement(Arrangement arrangement);
}
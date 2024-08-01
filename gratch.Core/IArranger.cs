using WhatTheTea.Gratch.Models;

namespace WhatTheTea.Gratch.Core;

/// <summary>
/// Provides mechanism to assign people on shifts and 
/// </summary>
public interface IArranger
{
    Arrangement ArrangeMany(IEnumerable<Person> people);
    Dictionary<DateTimeOffset, Person[]> GenerateTimeArrangement(Arrangement arrangement,
                                                                 DateTimeOffset start,
                                                                 DateTimeOffset end);
}
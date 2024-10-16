using WhatTheTea.Gratch.Models;

namespace WhatTheTea.Gratch.Abstractions;
public interface IArranger
{
    /// <summary>
    /// A base point in time, from which arrangements are calculated.
    /// </summary>
    DateTimeOffset BaseDateTime { get; }

    /// <summary>
    /// Generates arrangement for <see cref="Person"/> on specified <paramref name="dateTime"/>
    /// </summary>
    /// <returns>
    /// <see cref="Person"/> or null, if arrangement can't be evaluated for this <paramref name="dateTime"/>
    /// </returns>
    Person? ArrangeFor(DateTimeOffset dateTime);

    /// <summary>
    /// Configures internal collection of rules, may override rule-specific BaseDateTime.
    /// </summary>
    IArranger ConfigureRules(Action<IRulesCollection> configure);
}
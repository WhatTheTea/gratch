using WhatTheTea.Gratch.Models;

namespace WhatTheTea.Gratch.Abstractions;

/// <summary>
/// Rules collection to provide Fluent configuration API
/// </summary>
public interface IRulesCollection : IList<IRule>
{
    /// <summary>
    /// Method to evaluate all present rules in collection
    /// </summary>
    bool EvaluateFor(Person person, DateTimeOffset dateTime);
}

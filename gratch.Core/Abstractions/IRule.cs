using WhatTheTea.Gratch.Models;

namespace WhatTheTea.Gratch.Abstractions;

public interface IRule
{
    /// <summary>
    /// A base point in time, from which arrangements may be calculated.
    /// </summary>
    //DateTimeOffset BaseDateTime { get; set; }

    /// <summary>
    /// Method to decide if <paramref name="person"/> may be arranged on <paramref name="dateTime"/>
    /// </summary>
    bool Evaluate(DateTimeOffset dateTime);
}

namespace gratch.Arrangement.Rules;

/// <summary>
/// Rules collection to provide Fluent configuration API
/// </summary>
public interface IRulesCollection : IList<IRule>
{
    /// <summary>
    /// Method to evaluate all present rules in collection
    /// </summary>
    bool EvaluateFor(DateTimeOffset dateTime);
}

namespace gratch.Arrangement.Rules;

/// <summary>
/// Rule to define valid dates for arrangement
/// </summary>
public interface IRule
{
    /// <summary>
    /// Method to decide if object may be arranged on <paramref name="dateTime"/>
    /// </summary>
    bool Evaluate(DateTimeOffset dateTime);
}

using gratch.Arrangement.Rules;

namespace gratch.Arrangement;

/// <summary>
/// Arranges objects of type <see cref="T"/> based on rules and <see cref="BaseDateTime"/>
/// </summary>
/// <typeparam name="T">Type of object to be arranged</typeparam>
public interface IArranger<T>
{
    /// <summary>
    /// A base point in time, from which arrangements are calculated.
    /// </summary>
    DateTimeOffset BaseDateTime { get; }

    /// <summary>
    /// Generates arrangement for <see cref="T"/> on specified <paramref name="dateTime"/>
    /// </summary>
    /// <returns>
    /// <see cref="T"/> or null, if arrangement can't be evaluated for this <paramref name="dateTime"/>
    /// </returns>
    T? ArrangeFor(DateTimeOffset dateTime);

    /// <summary>
    /// Generates arrangement for <see cref="T"/> on specified range from <paramref name="start"/> to <paramref name="end"/>
    /// </summary>
    Dictionary<DateTimeOffset, T> ArrangeFor(DateTimeOffset start, DateTimeOffset end);

    /// <summary>
    /// Configures internal collection of rules, may override rule-specific BaseDateTime.
    /// </summary>
    IArranger<T> ConfigureRules(Action<IRulesCollection> configure);
}
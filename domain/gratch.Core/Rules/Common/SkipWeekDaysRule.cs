namespace gratch.Arrangement.Rules.Common;
public class SkipWeekDaysRule(IEnumerable<DayOfWeek> blacklist) : IRule
{
    public bool Evaluate(DateTimeOffset dateTime) => !blacklist.Contains(dateTime.DayOfWeek);
}

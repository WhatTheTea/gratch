namespace gratch.Arrangement.Rules.Common;
public class SkipWeekDaysRule(IEnumerable<DayOfWeek> blacklist) : IRule
{
    public bool Evaluate(DateTime dateTime) => !blacklist.Contains(dateTime.DayOfWeek);
}

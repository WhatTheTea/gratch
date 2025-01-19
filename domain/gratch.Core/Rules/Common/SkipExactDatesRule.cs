namespace gratch.Arrangement.Rules.Common;
public class SkipExactDatesRule(IEnumerable<DateTimeOffset> dates) : IRule
{
    public bool Evaluate(DateTimeOffset dateTime) => !dates.Contains(dateTime);
}

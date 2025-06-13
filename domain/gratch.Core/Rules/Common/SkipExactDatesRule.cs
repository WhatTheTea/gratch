namespace gratch.Arrangement.Rules.Common;
public class SkipExactDatesRule(IEnumerable<DateTime> dates) : IRule
{
    public bool Evaluate(DateTime dateTime) => !dates.Contains(dateTime);
}

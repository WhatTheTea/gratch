using WhatTheTea.Gratch.Abstractions;

namespace WhatTheTea.Gratch.Core.Rules;
public class SkipWeekDaysRule(IEnumerable<DayOfWeek> blacklist) : IRule
{
    public bool Evaluate(DateTimeOffset dateTime) => !blacklist.Contains(dateTime.DayOfWeek);
}

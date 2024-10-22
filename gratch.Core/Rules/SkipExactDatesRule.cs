using WhatTheTea.Gratch.Core.Abstractions;

namespace WhatTheTea.Gratch.Core.Rules;
public class SkipExactDatesRule(IEnumerable<DateTimeOffset> dates) : IRule
{
    public bool Evaluate(DateTimeOffset dateTime) => !dates.Contains(dateTime);
}

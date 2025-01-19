using WhatTheTea.Gratch.Core.Abstractions;
using WhatTheTea.Gratch.Core.Rules;

namespace WhatTheTea.Gratch.Core;
public static class RulesCollectionExtensions
{
    public static IRulesCollection AddEverydayRule(this IRulesCollection rules) =>
         rules.AddRule(new EverydayRule());
    public static IRulesCollection AddSkipWeekDaysRule(this IRulesCollection rules, IEnumerable<DayOfWeek> blacklist) =>
        rules.AddRule(new SkipWeekDaysRule(blacklist));
    public static IRulesCollection AddSkipExactDatesRule(this IRulesCollection rules, IEnumerable<DateTimeOffset> dates) =>
        rules.AddRule(new SkipExactDatesRule(dates));

    private static IRulesCollection AddRule(this IRulesCollection rules, IRule rule)
    {
        rules.Add(rule);
        return rules;
    }

}

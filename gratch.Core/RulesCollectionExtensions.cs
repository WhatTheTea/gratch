using WhatTheTea.Gratch.Abstractions;

namespace WhatTheTea.Gratch.Core;
public static class RulesCollectionExtensions
{
    public static IRulesCollection AddOneByOneRule(this IRulesCollection rules)
    {
        rules.Add(new OneByOneRule());
        return rules;
    }
}

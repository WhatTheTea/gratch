using WhatTheTea.Gratch.Core.Abstractions;

namespace WhatTheTea.Gratch.Core;

internal class RulesCollection() : List<IRule>, IRulesCollection
{
    public bool EvaluateFor(DateTimeOffset dateTime) =>
        this.Select(x => x.Evaluate(dateTime))
            .Aggregate(true, (res, val) => res && val);
}

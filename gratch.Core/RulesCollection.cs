using WhatTheTea.Gratch.Abstractions;
using WhatTheTea.Gratch.Models;

namespace WhatTheTea.Gratch.Core;

internal class RulesCollection(Func<Person[]> peopleFactory) : List<IRule>, IRulesCollection
{
    public bool EvaluateFor(Person person, DateTimeOffset dateTime) =>
        this.Select(x => x.Evaluate(person, dateTime, [.. peopleFactory()]))
            .Aggregate(true, (res, val) => res && val);
}

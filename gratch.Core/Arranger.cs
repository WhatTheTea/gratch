using WhatTheTea.Gratch.Abstractions;
using WhatTheTea.Gratch.Models;

namespace WhatTheTea.Gratch.Core;
public class Arranger(IEnumerable<Person> people, DateTimeOffset baseDateTimeOffset) : IArranger
{
    private readonly RulesCollection rules = new(people.ToArray);
    private readonly List<Person> people = new(people);

    public DateTimeOffset BaseDateTime { get; private set; } = baseDateTimeOffset;

    public IArranger ConfigureRules(Action<IRulesCollection> configure)
    {
        configure(this.rules);
        foreach (var rule in this.rules)
        {
            rule.BaseDateTime = this.BaseDateTime;
        }

        return this;
    }

    public Person? ArrangeFor(DateTimeOffset dateTime)
    {
        foreach (var person in this.people)
        {
            if (this.rules.EvaluateFor(person, dateTime))
            {
                return person;
            }
        }
        return null;
    }
}
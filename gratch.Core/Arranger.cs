using WhatTheTea.Gratch.Models;

namespace WhatTheTea.Gratch.Core;
public class Arranger
{
    private readonly HashSet<IRule> rules = [];
    private readonly List<Person> people = [];

    /// <summary>
    /// A base point in time, from which arrangements are calculated
    /// </summary>
    public DateTimeOffset BaseDateTime { get; private set; }

    public Arranger(IEnumerable<Person> people, DateTimeOffset baseDateTimeOffset)
    {
        this.people = new(people);
        this.BaseDateTime = baseDateTimeOffset;
    }

    /// <summary>
    /// Ensures rule is applied to this arranger
    /// </summary>
    public void AddRule(IRule rule)
    {
        this.rules.Add(rule);
        rule.BaseDateTimeOffset = this.BaseDateTime;
    }

    public Person? ArrangeForDateTime(DateTimeOffset dateTime)
    {
        foreach (var person in this.people)
        {
            if (this.EvaluateAllRulesFor(person, dateTime))
            {
                return person;
            }
        }
        return null;
    }

    private bool EvaluateAllRulesFor(Person person, DateTimeOffset dateTime) =>
        this.rules.Select(x => x.Evaluate(person, dateTime, [.. this.people]))
                  .Aggregate(true, (res, val) => res && val);
}

public interface IRule
{
    DateTimeOffset BaseDateTimeOffset { get; set; }
    bool Evaluate(Person person, DateTimeOffset dateTime, Person[] people);
}

public class OneByOneRule : IRule
{
    public DateTimeOffset BaseDateTimeOffset { get; set; }

    public bool Evaluate(Person person, DateTimeOffset dateTime, Person[] people)
    {
        int totalDays = (dateTime - this.BaseDateTimeOffset).Days;
        int expectedIndex = totalDays % people.Length;
        return people[expectedIndex] == person;
    }
}

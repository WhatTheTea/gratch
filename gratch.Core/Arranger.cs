using WhatTheTea.Gratch.Abstractions;
using WhatTheTea.Gratch.Models;

namespace WhatTheTea.Gratch.Core;
public class Arranger(IEnumerable<Person> people, DateTimeOffset baseDateTime) : IArranger
{
    private readonly RulesCollection rules = [];
    private readonly Person[] people = [.. people];
    private HashSet<DateTimeOffset> calculatedDateTimes = [];

    public DateTimeOffset BaseDateTime
    {
        get => baseDateTime;
        private set
        {
            baseDateTime = value;
            this.calculatedDateTimes.Clear();
        }
    }
    public IArranger ConfigureRules(Action<IRulesCollection> configure)
    {
        configure(this.rules);
        this.calculatedDateTimes.Clear();

        return this;
    }

    public Person? ArrangeFor(DateTimeOffset dateTime)
    {
        this.EnsureDateTimeIsCalculated(dateTime);

        var peopleCount = this.people.Length;
        bool isArrangementValid = peopleCount > 0 && dateTime > baseDateTime;
        var index = isArrangementValid
            ? (this.calculatedDateTimes.Count % peopleCount) - 1
            : -1;

        return this.people.ElementAtOrDefault(index);
    }

    private void EnsureDateTimeIsCalculated(DateTimeOffset dateTime)
    {
        var isCalculated = this.calculatedDateTimes.Contains(dateTime);
        if (!isCalculated)
        {
            this.CalculateArrangementsUntil(dateTime);
        }
    }

    private void CalculateArrangementsUntil(DateTimeOffset dateTime)
    {
        var lastDateTime = this.BaseDateTime.AddDays(this.calculatedDateTimes.Count);
        var diff = dateTime - lastDateTime;

        if (diff.Days < 0)
        {
            return;
        }

        var validDates = Enumerable.Range(0, diff.Days + 1)
            .Select(x => lastDateTime.AddDays(x))
            .Where(this.rules.EvaluateFor)
            .ToHashSet();

        this.calculatedDateTimes = validDates;
    }
}
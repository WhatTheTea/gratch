using WhatTheTea.Gratch.Abstractions;
using WhatTheTea.Gratch.Models;

namespace WhatTheTea.Gratch.Core;
public class Arranger(IEnumerable<Person> people, DateTimeOffset baseDateTime) : IArranger
{
    private readonly RulesCollection rules = [];
    private readonly Person[] people = [..people];
    private readonly HashSet<DateTimeOffset> calculatedDateTimes = [];

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
        bool isArrangementValid = peopleCount > 0 && dateTime < baseDateTime;
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
            this.calculatedDateTimes.Clear();
            var diff = dateTime - this.BaseDateTime;
            for (int i = 0; i <= diff.Days; i++)
            {
                var nextDateTime = this.BaseDateTime.AddDays(i);

                if (this.rules.EvaluateFor(nextDateTime))
                {
                    this.calculatedDateTimes.Add(nextDateTime);
                }
            }
        }
    }
}
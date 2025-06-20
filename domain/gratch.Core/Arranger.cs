﻿using System.Collections.Immutable;

using gratch.Arrangement.Rules;

namespace gratch.Arrangement;
public class Arranger<T>(IEnumerable<T> arrangeables, DateTime baseDateTime) : IArranger<T>
{
    private readonly RulesCollection rules = [];
    private readonly T[] arrangeables = [.. arrangeables];
    private ImmutableSortedSet<DateTime> calculatedDateTimes = [];

    public DateTime BaseDateTime
    {
        get => baseDateTime.Date;
        private set
        {
            baseDateTime = value;
            this.calculatedDateTimes.Clear();
        }
    }

    public IArranger<T> ConfigureRules(Action<IRulesCollection> configure)
    {
        configure(this.rules);
        this.calculatedDateTimes.Clear();

        return this;
    }

    public Dictionary<DateTime, T> ArrangeFor(DateTime start, DateTime end) =>
        Enumerable.Range(0, (end - start).Days + 1)
                  .Select(d => start.AddDays(d))
                  .Select(date => (date, arrangement: this.ArrangeFor(date)!))
                  .ToDictionary(pair => pair.date, pair => pair.arrangement);

    public T? ArrangeFor(DateTime dateTime)
    {
        this.EnsureDateTimeIsCalculated(dateTime);

        var peopleCount = this.arrangeables.Length;
        var dateTimeIndex = this.calculatedDateTimes.IndexOf(dateTime);
        bool isArrangementValid = peopleCount > 0 && dateTime >= this.BaseDateTime;

        var index = isArrangementValid
            ? dateTimeIndex % peopleCount
            : -1;

        return this.arrangeables.ElementAtOrDefault(index);
    }

    private void EnsureDateTimeIsCalculated(DateTime dateTime)
    {
        var isCalculated = this.calculatedDateTimes.Contains(dateTime);
        if (!isCalculated)
        {
            this.CalculateArrangementsUntil(dateTime);
        }
    }

    private void CalculateArrangementsUntil(DateTime dateTime)
    {
        var lastDateTime = this.BaseDateTime.AddDays(this.calculatedDateTimes.Count);
        var diff = dateTime - lastDateTime;

        if (diff.Days < 0)
        {
            return;
        }

        var validDates = Enumerable.Range(0, diff.Days + 1)
            .Select(x => lastDateTime.AddDays(x))
            .Where(this.rules.EvaluateFor);

        this.calculatedDateTimes = [.. this.calculatedDateTimes, .. validDates];
    }
}
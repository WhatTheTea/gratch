﻿using Microsoft.Extensions.Time.Testing;
using WhatTheTea.Gratch.Models;
using WhatTheTea.Gratch.Core;

namespace WhatTheTea.Gratch.Tests.Core;
/// <summary>
/// A set of AAA unit tests
/// </summary>
public class BasicArrangementTests
{
    private readonly FakeTimeProvider timeProvider = new(new DateTime(2024, 07, 01));
    private DateTimeOffset Now => this.timeProvider.GetLocalNow();
    private static Person[] GetFakePeople(int count) =>
        Enumerable.Range(1, count)
                  .Select(x => new Person(x.ToString()))
                  .ToArray();
    private static Group GetFakeGroup(int count) => new(GetFakePeople(count));

    [Fact]
    public void PeopleArrangedOneByOne()
    {
        var group = GetFakeGroup(5);
        var arranger = new Arranger(group, this.Now)
            .ConfigureRules(x => x.AddOneByOneRule());

        var result = arranger.ArrangeFor(this.Now.AddDays(2));

        result.Should().Be(group[2]);
    }

    [Theory]
    [InlineData(0, 10)] // No people
    [InlineData(10, 10)] // Overflow
    [InlineData(10, -10)] // Negative days, overflow
    [InlineData(0, -10)] // No people, negative
    public void PeopleAreArrangedInEdgeCases(int peopleCount, int daysFromNow)
    {
        var arrangementDate = this.Now.AddDays(daysFromNow);
        var group = GetFakeGroup(peopleCount);
        var arranger = new Arranger(group, this.Now)
            .ConfigureRules(x => x.AddOneByOneRule());

        var result = arranger.ArrangeFor(arrangementDate);

        result.Should().Be(group.FirstOrDefault());
    }
}

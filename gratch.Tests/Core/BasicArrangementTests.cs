using Xunit;
using FluentAssertions;
using Microsoft.Extensions.Time.Testing;
using WhatTheTea.Gratch.Models;
using WhatTheTea.Gratch.Core;

namespace WhatTheTea.Gratch.Tests.Core;
/// <summary>
/// A set of AAA unit tests
/// </summary>
public class BasicArrangementTests
{
    /// <summary>
    /// Checks if people are arranged one by one in span of one month
    /// </summary>
    [Fact]
    public void PeopleAreArrangedOneByOne()
    {
        var timeProvider = new FakeTimeProvider(new DateTime(2024, 07, 01));
        var now = timeProvider.GetLocalNow();
        var people = Enumerable.Range(1, 30).Select(x => new Person(x.ToString()));
        var arranger = new BasicArranger();

        var arrangement = arranger.ArrangeMany(people);
        var timeArrangement = arranger.GenerateTimeArrangement(arrangement,
                                                               now,
                                                               now.AddDays(30));

        timeArrangement.Select(x => x.Value[0]).Should().BeEquivalentTo(people);
    }

    [Theory]
    [InlineData(0,31)] // No people
    [InlineData(10, 0)] // No days
    public void PeopleAreNotArrangedIfArgumentsNotValid(int peopleCount, int daysCount)
    {
        var timeProvider = new FakeTimeProvider(new DateTime(2024, 07, 01));
        var now = timeProvider.GetLocalNow();
        var people = Enumerable.Range(1, peopleCount).Select(x => new Person(x.ToString()));
        var arranger = new BasicArranger();

        var arrangement = arranger.ArrangeMany(people);
        var timeArrangement = arranger.GenerateTimeArrangement(arrangement,
                                                               now,
                                                               now.AddDays(daysCount));

        timeArrangement.Should().BeEmpty();
    }
}

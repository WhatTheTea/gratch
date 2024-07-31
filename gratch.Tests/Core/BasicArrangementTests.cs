using Xunit;
using FluentAssertions;
using Microsoft.Extensions.Time.Testing;
using WhatTheTea.Gratch.Models;
using WhatTheTea.Gratch.Core;

namespace WhatTheTea.Gratch.Tests.Core;
public class BasicArrangementTests
{
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
}

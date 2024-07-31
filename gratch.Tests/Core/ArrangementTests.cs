using Xunit;
using FluentAssertions;
using Microsoft.Extensions.Time.Testing;
using WhatTheTea.Gratch.Models;
using WhatTheTea.Gratch.Core;

namespace WhatTheTea.Gratch.Tests.Core;
public class ArrangementTests
{
    [Fact]
    public void PeopleAreArrangedOneByOne()
    {
        var timeProvider = new FakeTimeProvider(new DateTime(2024, 07, 01));
        var people = Enumerable.Range(1, 30).Select(x => new Person(x.ToString()));
        IArranger arranger = new BasicArranger(timeProvider);

        var arrangement = arranger.ArrangeMany(people);
        var timeArrangement = arranger.GenerateTimeArrangement(arrangement);

        timeArrangement.Select(x => x.Value[0]).Should().BeEquivalentTo(people);
    }
}

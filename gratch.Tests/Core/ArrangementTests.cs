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
        var arranger = new BasicArranger(timeProvider);

        arranger.ArrangeMany(people);

        people.Should().Satisfy(x => x.Name == x.Shift.Day.ToString());
    }
}

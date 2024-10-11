using Microsoft.Extensions.Time.Testing;
using WhatTheTea.Gratch.Models;
using WhatTheTea.Gratch.Core;
using FluentAssertions.Common;

namespace WhatTheTea.Gratch.Tests.Core;
/// <summary>
/// A set of AAA unit tests
/// </summary>
public class BasicArrangementTests
{
    private readonly FakeTimeProvider timeProvider = new(new DateTime(2024, 10, 01));
    //private readonly BasicArranger arranger = new();
    private DateTimeOffset Now => this.timeProvider.GetLocalNow();
    private static Person[] GetFakePeople(int count) =>
        Enumerable.Range(1, count)
                  .Select(x => new Person(x.ToString()))
                  .ToArray();

    ///// <summary>
    ///// Checks if people are arranged one by one in span of one month
    ///// </summary>
    //[Fact]
    //public void PeopleAreArrangedOneByOne()
    //{
    //    var people = GetFakePeople(count: 30);

    //    var arrangement = this.arranger.ArrangeMany(people);
    //    var timeArrangement = this.arranger.GenerateTimeArrangement(arrangement,
    //                                                           this.Now,
    //                                                           this.Now.AddDays(30));

    //    timeArrangement.Select(x => x.Value[0]).Should().BeEquivalentTo(people);
    //}

    //[Theory]
    //[InlineData(0, 31)] // No people
    //[InlineData(10, 0)] // No days
    //public void PeopleAreNotArrangedIfArgumentsNotValid(int peopleCount, int daysCount)
    //{
    //    var people = GetFakePeople(peopleCount);

    //    var arrangement = this.arranger.ArrangeMany(people);
    //    var timeArrangement = this.arranger.GenerateTimeArrangement(arrangement,
    //                                                           this.Now,
    //                                                           this.Now.AddDays(daysCount));

    //    timeArrangement.Should().BeEmpty();
    //}

    //[Fact]
    //public void ValidArrangeOnOverflow()
    //{
    //    var people = GetFakePeople(count: 15);

    //    var arrangement = this.arranger.ArrangeMany(people);
    //    var timeArrangement = this.arranger.GenerateTimeArrangement(arrangement,
    //                                                           this.Now,
    //                                                           this.Now.AddDays(30));
    //    var overlapDay = this.Now.AddDays(15); // 2024-07-16
    //    timeArrangement[this.Now].Should().BeSameAs(timeArrangement[overlapDay]);
    //}
    [Fact]
    public void PersonArrangedOnCorrectDate()
    {
        var date = this.Now;
        var group = new Group();
        group.AddRange(GetFakePeople(5));
        var arranger = new Arranger(group, date);
        arranger.AddRule(new OneByOneRule());

        var result = arranger.ArrangeForDateTime(date.AddDays(2));

        result.Should().Be(group[2]);
    }
}

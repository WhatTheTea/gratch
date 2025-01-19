using Microsoft.Extensions.Time.Testing;
using WhatTheTea.Gratch.Core;
using gratch.Tests.TestModels;

namespace gratch.Tests.Core;

/// <summary>
/// A set of AAA unit tests
/// </summary>
public class BasicArrangementTests
{
    /*
      July, 2024-07, source: https://gogos.me/text-calendar-4x3/             

      Mon Tue Wed Thu Fri Sat Sun  
      ━━━━━━━━━━━━━━━━━━━━━━━━━━━  
        1   2   3   4   5   6   7 
        8   9  10  11  12  13  14 
       15  16  17  18  19  20  21 
       22  23  24  25  26  27  28 
       29  30  31                 

    */
    private readonly FakeTimeProvider timeProvider = new(new DateTime(2024, 07, 01));
    private DateTimeOffset Now => this.timeProvider.GetLocalNow();
    private static Person[] GetFakePeople(int count) =>
        Enumerable.Range(0, count)
                  .Select(x => new Person(x.ToString()))
                  .ToArray();
    private static Group GetFakeGroup(int count) => new(GetFakePeople(count));

    [Fact]
    public void PeopleArrangedOneByOne()
    {
        var group = GetFakeGroup(5);
        var arranger = new Arranger<Person>(group, this.Now)
            .ConfigureRules(x => x.AddEverydayRule());

        var result = arranger.ArrangeFor(this.Now.AddDays(2));

        result.ShouldBe(group[2]);
    }

    [Theory]
    [InlineData(0, 10)] // No people
    [InlineData(10, -10)] // Negative days, overflow
    [InlineData(0, -10)] // No people, negative
    public void PeopleAreArrangedInEdgeCases(int peopleCount, int daysFromNow)
    {
        var arrangementDate = this.Now.AddDays(daysFromNow);
        var group = GetFakeGroup(peopleCount);
        var arranger = new Arranger<Person>(group, this.Now)
            .ConfigureRules(x => x.AddEverydayRule());

        var result = arranger.ArrangeFor(arrangementDate);

        result.ShouldBe(null);
    }

    [Fact]
    public void ArrangerIsSkippingHolidays()
    {
        var group = GetFakeGroup(7);
        var arranger = new Arranger<Person>(group, this.Now)
            .ConfigureRules(x => x.AddEverydayRule().AddSkipWeekDaysRule([DayOfWeek.Saturday, DayOfWeek.Sunday]));

        var result = arranger.ArrangeFor(this.Now.AddDays(7));

        result.ShouldBe(group[5]);
    }

    [Fact]
    public void ArrangerIsSkippingExactDays()
    {
        var group = GetFakeGroup(7);
        var arranger = new Arranger<Person>(group, this.Now)
            .ConfigureRules(x => x.AddEverydayRule().AddSkipExactDatesRule([this.Now.AddDays(1)]));

        var result = arranger.ArrangeFor(this.Now.AddDays(2));

        result.ShouldBe(group[1]);
    }
}

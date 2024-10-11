using WhatTheTea.Gratch.Abstractions;
using WhatTheTea.Gratch.Models;

namespace WhatTheTea.Gratch.Core;

internal class OneByOneRule : IRule
{
    public DateTimeOffset BaseDateTime { get; set; }

    public bool Evaluate(Person person, DateTimeOffset dateTime, Person[] people)
    {
        int totalDays = (dateTime - this.BaseDateTime).Days;
        int expectedIndex = totalDays % people.Length;
        return people[expectedIndex] == person;
    }
}

namespace WhatTheTea.Gratch.Models;
public class Arrangement
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<Person> PeopleArrangement { get; set; } = [];

    public Arrangement(string title)
    {
        this.Title = title;
    }

    public Dictionary<DateTimeOffset, Person> GenerateForPeriod(DateTimeOffset start, DateTimeOffset end)
    {
    }
}

namespace WhatTheTea.Gratch.Models;

public enum ArrangementKind
{
    Basic
}

public class Arrangement(string title)
{
    public int Id { get; set; }
    public string Title { get; set; } = title;
    public Dictionary<int, Person[]> PeopleArrangement { get; set; } = [];
    public ArrangementKind Kind { get; set; }
}

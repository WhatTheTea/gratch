namespace WhatTheTea.Gratch.Models;

public enum ArrangementKind
{
    Basic
}

/// <summary>
/// Represents arrangement of people. <br/>
/// Kind must be specified to correctly read data.
/// </summary>
/// <remarks>
/// Arrangements expressed as pairs of shift and person array to support many on one shift type.
/// </remarks>
/// <param name="title"></param>
public class Arrangement(string title = "")
{
    public int Id { get; set; }
    public string Title { get; set; } = title;
    public Dictionary<int, Person[]> PeopleArrangement { get; set; } = [];
    public ArrangementKind Kind { get; set; }
}

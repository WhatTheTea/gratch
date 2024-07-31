namespace WhatTheTea.Gratch.Models;

public class Person
{
    public int Id { get; protected set; }
    public string Name { get; protected set; }
    public DateTimeOffset Shift { get; protected set; }

    public Person(string name, DateTimeOffset? shift = null)
    {
        this.Name = name;
        this.Shift = shift ?? default;
    }
}

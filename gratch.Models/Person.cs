namespace WhatTheTea.Gratch.Models;

public class Person
{
    public int Id { get; protected set; }
    public string Name { get; protected set; }
    public DateTime Shift { get; protected set; }

    public Person(string name, DateTime shift)
    {
        this.Name = name;
        this.Shift = shift;
    }
}

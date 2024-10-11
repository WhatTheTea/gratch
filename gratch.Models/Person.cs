using System.Diagnostics;

namespace WhatTheTea.Gratch.Models;

/// <summary>
/// Class to represent person, which can be assigned to specific date 
/// </summary>
[DebuggerDisplay("{Id} : {Name}")]
public class Person(string name)
{
    public int Id { get; protected set; }

    public string Name { get; protected set; } = name;

    public string Email { get; protected set; } = string.Empty;
}

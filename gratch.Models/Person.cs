﻿namespace WhatTheTea.Gratch.Models;

/// <summary>
/// Class to represent person, which can be assigned to specific date 
/// </summary>
public class Person(string name)
{
    public int Id { get; protected set; }
    public string Name { get; protected set; } = name;
}

namespace WhatTheTea.Gratch.Models;
public class Group : List<Person>
{
    int Id { get; set; }
    string Title { get; set; }
}

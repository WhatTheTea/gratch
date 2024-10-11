
namespace WhatTheTea.Gratch.Models;
public class Group : List<Person>
{
    public Group(int id = 0, string title = "") : base()
    {
        this.Id = id;
        this.Title = title;
    }

    public Group(IEnumerable<Person> collection, int id = 0, string title = "") : base(collection)
    {
        this.Id = id;
        this.Title = title;
    }

    int Id { get; set; }
    string Title { get; set; }
}

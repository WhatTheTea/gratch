namespace gratch.Models;

public class Group : List<Person>
{
    public string Name { get; set; } = string.Empty;
}

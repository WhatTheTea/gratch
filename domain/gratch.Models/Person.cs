namespace gratch.Models;

public record Person(string Id, string Name)
{
    public static class Validate
    {
        public static bool Name(string name) => !string.IsNullOrEmpty(name);
    }
}

using System.Diagnostics;

namespace gratch.Tests.TestModels;

/// <summary>
/// Class to represent a person
/// </summary>
[DebuggerDisplay("{Id} : {Name}")]
public class Person(string name)
{
    public int Id { get; protected set; }

    public string Name { get; protected set; } = name;

    public string Email { get; protected set; } = string.Empty;
}

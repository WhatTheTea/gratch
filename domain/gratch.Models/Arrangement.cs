using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace gratch.Models;
public sealed class Arrangement(Dictionary<DateTimeOffset, Person> arrangement) : IReadOnlyDictionary<DateTimeOffset, Person>
{
    private readonly Dictionary<DateTimeOffset, Person> source = arrangement;

    public Person this[DateTimeOffset key] => ((IReadOnlyDictionary<DateTimeOffset, Person>)this.source)[key];

    public IEnumerable<DateTimeOffset> Keys => ((IReadOnlyDictionary<DateTimeOffset, Person>)this.source).Keys;

    public IEnumerable<Person> Values => ((IReadOnlyDictionary<DateTimeOffset, Person>)this.source).Values;

    public int Count => ((IReadOnlyCollection<KeyValuePair<DateTimeOffset, Person>>)this.source).Count;

    public bool ContainsKey(DateTimeOffset key) => ((IReadOnlyDictionary<DateTimeOffset, Person>)this.source).ContainsKey(key);
    public IEnumerator<KeyValuePair<DateTimeOffset, Person>> GetEnumerator() => ((IEnumerable<KeyValuePair<DateTimeOffset, Person>>)this.source).GetEnumerator();
    public bool TryGetValue(DateTimeOffset key, [MaybeNullWhen(false)] out Person value) => ((IReadOnlyDictionary<DateTimeOffset, Person>)this.source).TryGetValue(key, out value);
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this.source).GetEnumerator();
}

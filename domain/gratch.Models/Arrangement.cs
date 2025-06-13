using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace gratch.Models;
public sealed class Arrangement(Dictionary<DateTime, Person> arrangement) : IReadOnlyDictionary<DateTime, Person>
{
    private readonly Dictionary<DateTime, Person> source = arrangement;

    public Person this[DateTime key] => ((IReadOnlyDictionary<DateTime, Person>)this.source)[key];

    public IEnumerable<DateTime> Keys => ((IReadOnlyDictionary<DateTime, Person>)this.source).Keys;

    public IEnumerable<Person> Values => ((IReadOnlyDictionary<DateTime, Person>)this.source).Values;

    public int Count => ((IReadOnlyCollection<KeyValuePair<DateTime, Person>>)this.source).Count;

    public bool ContainsKey(DateTime key) => ((IReadOnlyDictionary<DateTime, Person>)this.source).ContainsKey(key);
    public IEnumerator<KeyValuePair<DateTime, Person>> GetEnumerator() => ((IEnumerable<KeyValuePair<DateTime, Person>>)this.source).GetEnumerator();
    public bool TryGetValue(DateTime key, [MaybeNullWhen(false)] out Person value) => ((IReadOnlyDictionary<DateTime, Person>)this.source).TryGetValue(key, out value);
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this.source).GetEnumerator();
}

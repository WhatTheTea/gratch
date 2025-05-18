namespace gratch.Utilities;
public static class DictionaryExtensions
{
    public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueFactory)
    {
        if (dictionary.TryGetValue(key, out var value))
        {
            return value;
        }
        else
        {
            value = valueFactory();
            dictionary.Add(key, value);
            return value;
        }
    }
}

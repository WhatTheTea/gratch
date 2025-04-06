namespace gratch.Helpers;

public static class ListExtensions
{
    /// <summary>
    /// Returns element at <paramref name="index"/> or nearest existing element if <paramref name="list"/>[<paramref name="index"/>] does not exist
    /// </summary>
    public static T? ElementAtNearest<T>(this IList<T> list, int index) => list.Count switch
    {
        < 1 => default,
        1 => list[0],
        _ => index switch
        {
            < 0 => list[0],
            var i when i >= list.Count => list[^1],
            _ => list[index],
        },
    };
}

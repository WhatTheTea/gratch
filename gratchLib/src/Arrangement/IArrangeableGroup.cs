namespace gratch.Library.Arrangement
{
    public interface IArrangeableGroup
    {
        IArrangement Arrangement { get; set; }
        IEnumerable<IArrangeable> Arrangeables { get; }
        IEnumerable<IArrangeable> Arranged { get; }
    }
}
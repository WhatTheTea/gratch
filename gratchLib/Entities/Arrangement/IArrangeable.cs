namespace gratchLib.Entities.Arrangement
{
    public interface IArrangeable
    {
        int Position { get; set; }
        bool IsArranged { get; }
    }
}
namespace gratchLib.Entities.Arrangement
{
    public interface IArrangementStrategy
    {
        void ArrangeAll(EArrangementMode mode = EArrangementMode.All);
        void Arrange(IArrangeable arrangeable);
        void ArrangeAt(IArrangeable arrangeable, int position);
    }

    public enum EArrangementMode
    {
        All,
        Arranged
    }
}
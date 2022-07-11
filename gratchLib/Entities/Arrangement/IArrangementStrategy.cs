namespace gratchLib.Entities.Arrangement
{
    public interface IArrangementStrategy
    {
        void ArrangeAll(EArrangementMode mode = EArrangementMode.All);
        void Arrange(IArrangeable arrangeable);
        void ArrangeTo(IArrangeable arrangeable, int position);
        void RemoveArrangement(IArrangeable arrangeable);
    }
}
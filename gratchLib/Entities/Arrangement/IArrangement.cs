using gratchLib.Entities.Arrangement;

namespace gratchLib.Entities.Arrangement
{
    public interface IArrangement
    {
        void ArrangeAll(EArrangementMode mode = EArrangementMode.All);
        void Arrange(IArrangeable arrangeable);
        void ArrangeTo(IArrangeable arrangeable, int position);
        void RemoveArrangement(IArrangeable arrangeable);
        void SetContext(IArrangeableGroup context);
    }

    public enum EArrangementMode
    {
        All,
        Arranged
    }
}
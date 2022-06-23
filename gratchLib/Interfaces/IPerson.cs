
namespace gratchLib
{
    public interface IPerson : IAssignable
    {
        IGroup Group { get; }
        string Name { get; set; }
        int Position { get; set; }
    }
}

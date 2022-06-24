namespace gratchLib
{
    public interface IAssignable<T> where T : class
    {
        void AssignTo(T schedule);
    }
}
namespace gratchLib
{
    public interface ISchedule
    {
        DateTimeRange Period { get; }
        IGroup Group { get; }

        IPerson this[DateTime date] { get; }

        void Assign(IAssignable assignable);
    }
}
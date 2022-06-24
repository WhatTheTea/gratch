namespace gratchLib
{
    public abstract class Schedule
    {
        public abstract void Assign(IAssignable<Schedule> assignable);
    }
}
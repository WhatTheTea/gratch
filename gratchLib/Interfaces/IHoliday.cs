namespace gratchLib
{
    public interface IHoliday
    {
        string Name { get; }
        DateTime Date { get; }

        void IsToday();
        void IsEqual(DateTime date);
    }
}
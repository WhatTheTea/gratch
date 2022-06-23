
namespace gratchLib
{
    public interface IGroup
    {
        string Name { get; set; }
        IList<IPerson> People { get; }
        ICalendar Calendar { get; }

        void AddPerson(string name);
        void RemovePerson(IPerson person);
    }
}

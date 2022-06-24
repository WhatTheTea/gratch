

namespace gratchLib
{
    public class Group : IGroup
    {
        protected List<Person> people = new(); 

        public virtual string Name { get; set; } = string.Empty;
        public virtual IList<IPerson> People => (IList<IPerson>)people.AsReadOnly();
        public virtual ICalendar Calendar { get; } = new Calendar();

        public virtual void AddPerson(string name)
        {

        }
        public virtual void RemovePerson(IPerson person)
        {

        }
    }
}

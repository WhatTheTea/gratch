namespace gratchLib.Entities
{
    public interface IGroup
    {
        int Id { get; set; }
        string Name { get; set; }
        IEnumerable<Person> People { get; }
        Calendar Calendar { get; set; }

        void AddPerson(Person person);
        void RemovePerson(Person person);
    }
}

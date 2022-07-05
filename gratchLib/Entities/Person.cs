namespace gratchLib.Entities
{
    public class Person
    {

        private int _position;
        private string _name;

        public int Id { get; set; }
        public string Name { get => _name; set => Rename(value); }
        public int Position { get => _position; set => ChangePosition(value); }

        public Group Group { get; set; }

        public bool IsActive => Position > 0;

        public Person() { }
        public Person(string name, Group group)
        {
            _name = name;
            Group = group;
        }

        public virtual void Rename(string name)
        {
            if (!Group.Contains(name))
            {
                _name = name;
            }
        }
        public virtual void ChangePosition(int pos)
        {
            var isPosValid = pos >= 0 && pos <= Group.ActivePeople?.Count() + 1;

            if (isPosValid)
            {
                _position = pos;
            }
        }
    }
}

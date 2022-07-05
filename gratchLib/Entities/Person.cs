using System.Reactive.Subjects;

namespace gratchLib.Entities
{
    public class Person
    {
        private int _position;
        private string _name;

        public int Id { get; set; }
        public string Name { get => _name; set => Rename(value); }
        public int Position { get => _position; set => ChangePosition(value); }
        public bool IsActive => Position > 0;
        public Group Group { get; set; }

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
        /// <summary>
        /// Changes person's position.
        /// </summary>
        /// <param name="position"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public virtual void ChangePosition(int position)
        {
            var isPosInRange = position >= 0 && position <= Group.ActivePeople?.Count() + 1;

            if (isPosInRange)
            {
                _position = position;
            } else
            {
                throw new ArgumentOutOfRangeException(nameof(position));
            }
        }
    }
}

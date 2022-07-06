using System.Reactive.Subjects;

namespace gratchLib.Entities
{
    public class Person
    {
        private int _position = 0;
        private string _name = string.Empty;

        public int Id { get; set; }
        public string Name { get => _name; set => Rename(value); }
        public int Position { get => _position; set => ChangePosition(value); }
        public bool IsActive => Position > 0;
        public Group? Group { get; set; }

        public Person(string name) => _name = name;
        public Person(string name, Group group) : this(name) => Group = group;

        public virtual void Rename(string name)
        {
            _name = name;
            // TODO: OnNext();
        }
        /// <summary>
        /// Changes person's position.
        /// </summary>
        /// <param name="position"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public virtual void ChangePosition(int position)
        {
            var isPosInRange = position >= 0 && position <= Group.ActivePeople.Count() + 1;
            _position = isPosInRange ? position 
                                     : throw new ArgumentOutOfRangeException(nameof(position));
        }
    }
}

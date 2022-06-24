using SQLite;

using SQLiteNetExtensions.Attributes;

namespace gratchLib
{
    [Table("Groups")]
    public class GroupSQLite : Group
    {
#region DBMapping
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }

        [ForeignKey(typeof(CalendarSQLite))]
        public int CalendarId { get; set; }

        [Column(nameof(Name)), NotNull]
        public new string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public new IList<Person> People => base.People;

        [OneToOne(nameof(CalendarId), CascadeOperations = CascadeOperation.All)]
        public override Calendar Calendar { get; } = new CalendarSQLite();
#endregion
        public override void AddPerson(string name)
        {
            if (!Contains(name))
            {
                var person = new PersonSQLite(this, name); // New instance
                person.Position = ActivePeople.Last().Position + 1; // make active
                // subscribe to observables
                var sub = person.WhenPositionChanged.Subscribe(x => ShiftPositionsAfter(x));
                // add to collections
                people.Add(person);
                subscriptions.Add(sub);
            }
        }

    }
}

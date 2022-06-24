using SQLite;

using SQLiteNetExtensions.Attributes;

namespace gratchLib
{
    [Table("Groups")]
    public class GroupSQLite : Group
    {
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
        public new IList<IPerson> People => base.People;

        [OneToOne(nameof(CalendarId), CascadeOperations = CascadeOperation.All)]
        public new ICalendar Calendar => base.Calendar;

    }
}

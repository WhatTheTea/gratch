using SQLite;

using SQLiteNetExtensions.Attributes;

namespace gratchLib
{
    [Table("Calendars")]
    public class CalendarSQLite : Calendar
    {
        #region DBMapping
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }

        [ForeignKey(typeof(GroupSQLite))]
        public int GroupId { get; set; }


        [OneToOne(nameof(GroupId),CascadeOperations = CascadeOperation.All)]
        public Group Group { get; set; }


        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public new IList<Holiday> Holidays => base.Holidays;

        [TextBlob(nameof(WeekendBlob), CascadeOperations = CascadeOperation.All), ]
        public new IList<DayOfWeek> Weekend => base.Weekend;
        public string WeekendBlob { get; set; } = string.Empty;

        [Column(nameof(StartDate))]
        public new DateTime StartDate => base.StartDate;
        #endregion

        public CalendarSQLite(Group group)
        {
            this.Group = group;
        }
    }
}
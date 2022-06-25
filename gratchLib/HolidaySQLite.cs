using SQLite;
using SQLiteNetExtensions.Attributes;

namespace gratchLib
{
    [Table("Holidays")]
    public class HolidaySQLite : Holiday
    {
        #region DBMapping
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }

        [ForeignKey(typeof(CalendarSQLite))]
        public int CalendarId { get; set; }


        [Column(nameof(Date)), NotNull]
        public new DateTime Date => base.Date;

        [Column(nameof(Name)), NotNull]
        public new string Name => base.Name;
        #endregion

        public HolidaySQLite(DateTime date, string name) : base(date, name)
        {

        }
    }
}

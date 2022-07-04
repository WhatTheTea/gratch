using SQLite;

namespace gratchLib.Database
{
    public abstract class SQLiteUnitOfWork : IUnitOfWork<SQLiteConnection, GroupSQLite, PersonSQLite, CalendarSQLite, HolidaySQLite>
    {
        protected SQLiteConnection _connection = new(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\gratch.db3");
        protected SQLiteRepository<GroupSQLite> groups;
        protected SQLiteRepository<PersonSQLite> people;
        protected SQLiteRepository<CalendarSQLite> calendars;
        protected SQLiteRepository<HolidaySQLite> holidays;


        public virtual IRepository<GroupSQLite, SQLiteConnection> Groups => groups;
        public virtual IRepository<PersonSQLite, SQLiteConnection> People => people;
        public virtual IRepository<CalendarSQLite, SQLiteConnection> Calendars => calendars;
        public virtual IRepository<HolidaySQLite, SQLiteConnection> Holidays => holidays;

        public SQLiteUnitOfWork()
        {
            groups = new(_connection);
            people = new(_connection);
            calendars = new(_connection);
            holidays = new(_connection);
        }

        public abstract void BeginTransaction();
        public abstract bool Commit();
        public abstract void Rollback();
        public abstract void SaveChanges();
    }
}

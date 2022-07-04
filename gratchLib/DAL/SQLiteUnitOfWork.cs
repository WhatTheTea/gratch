using SQLite;

namespace gratchLib.DAL
{
    public abstract class SQLiteUnitOfWork : IUnitOfWork<SQLiteConnection, GroupSQLite, PersonSQLite, CalendarSQLite, HolidaySQLite>, IDisposable
    {
        protected SQLiteConnection _connection = new(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\gratch.db3");
        protected SQLiteRepository<GroupSQLite> groups;
        protected SQLiteRepository<PersonSQLite> people;
        protected SQLiteRepository<CalendarSQLite> calendars;
        protected SQLiteRepository<HolidaySQLite> holidays;
        private bool disposedValue;

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

        public virtual void BeginTransaction() => _connection.BeginTransaction();
        public virtual void Commit() => _connection.Commit();
        public virtual void Rollback() => _connection.Rollback();


        #region IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _connection.Dispose();
                    groups.Dispose();
                    people.Dispose();
                    calendars.Dispose();
                    holidays.Dispose();
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
                // TODO: установить значение NULL для больших полей
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

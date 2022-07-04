using SQLite;

using SQLiteNetExtensions.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gratchLib.DAL
{
    public class SQLiteRepository<T> : IRepository<T, SQLiteConnection>, IDisposable
                    where T : new()
    {
        protected SQLiteConnection _connection;
        private bool disposedValue;

        public virtual SQLiteConnection Connection => _connection;

        public SQLiteRepository(SQLiteConnection connection = null)
        {
            if (connection == null) _connection = new(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\gratch.db3");
            Connection.CreateTable<T>();
        }

        public virtual List<T> GetAllItems() => _connection.GetAllWithChildren<T>(recursive: true);
        public virtual void Insert(T item) => _connection.InsertOrReplaceWithChildren(item, true);
        public virtual void Remove(T item) => _connection.Delete(item);
        public virtual void Update(T item) => _connection.UpdateWithChildren(item);

        #region IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _connection.Dispose();
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

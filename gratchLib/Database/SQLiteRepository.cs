using SQLite;

using SQLiteNetExtensions.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gratchLib.Database
{
    public class SQLiteRepository<T> : IRepository<T, SQLiteConnection>
                    where T : new()
    {
        protected SQLiteConnection _connection;
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
    }
}

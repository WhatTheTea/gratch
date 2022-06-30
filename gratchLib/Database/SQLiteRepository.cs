using SQLite;

using SQLiteNetExtensions.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gratchLib.Database
{
    public abstract class SQLiteRepository<T> : IRepository<T, SQLiteConnection>
                    where T : new()
    {
        protected SQLiteConnection _connection = new(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\gratch.db3");
        public virtual SQLiteConnection Connection => _connection;

        protected SQLiteRepository()
        {
            Connection.CreateTable<T>();
        }

        public virtual void GetAllItems() => _connection.GetAllWithChildren<T>();
        public virtual void Insert(T item) => _connection.InsertOrReplaceWithChildren(item);
        public virtual void Remove(T item) => _connection.Delete(item);
        public virtual void Update(T item) => _connection.UpdateWithChildren(item);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gratchLib.Database
{
    public interface IRepository<T,TConnection> 
        where T : new()
        where TConnection : class
    {
        TConnection Connection { get; }

        void Insert(T item);
        void Update(T item);
        void Remove(T item);
        List<T> GetAllItems();
    }
}

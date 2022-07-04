using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gratchLib.Database
{
    public interface IUnitOfWork<TConnection, TGroup, TPerson, TCalendar, THoliday> 
        where TConnection : class
        where TGroup : Group, new()
        where TPerson : Person, new()
        where TCalendar : Calendar, new()
        where THoliday : Holiday, new()
    {
        void BeginTransaction();
        void SaveChanges();
        bool Commit();
        void Rollback();

        IRepository<TPerson, TConnection> People { get; }
        IRepository<TGroup, TConnection> Groups { get; }
        IRepository<TCalendar,TConnection> Calendars { get; }
        IRepository<THoliday, TConnection> Holidays { get; }
    }
}

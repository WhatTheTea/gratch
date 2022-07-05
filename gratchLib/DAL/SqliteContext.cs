using Microsoft.EntityFrameworkCore;

using gratchLib.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace gratchLib.DAL
{
    public class SqliteContext : BaseContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\gratch.db3";

            optionsBuilder.UseSqlite(connectionStringBuilder.ConnectionString);
        }
        public SqliteContext() : base()
        {

        }
    }
}

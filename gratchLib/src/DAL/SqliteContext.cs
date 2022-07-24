using Microsoft.EntityFrameworkCore;

using Microsoft.Data.Sqlite;

namespace gratch.Library.DAL
{
    public class SqliteContext : BaseContext
    {
        
        // TODO: Move to unit tests project 
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

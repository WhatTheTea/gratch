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
    public class SqliteContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Holiday> Holidays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\gratch.db3";

            optionsBuilder.UseSqlite(connectionStringBuilder.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                        .ApplyConfiguration(new Configurations.GroupConfiguration())
                        .ApplyConfiguration(new Configurations.PersonConfiguration())
                        .ApplyConfiguration(new Configurations.CalendarConfiguration())
                        .ApplyConfiguration(new Configurations.HolidayConfiguration());
        }
    }
}

using gratchLib.Entities;

using Microsoft.EntityFrameworkCore;

namespace gratchLib.DAL
{
    public class BaseContext : DbContext
    {
        public virtual DbSet<Group>? Groups { get; set; }
        public virtual DbSet<Person>? People { get; set; }
        public virtual DbSet<Calendar>? Calendars { get; set; }
        public virtual DbSet<Holiday>? Holidays { get; set; }

        public BaseContext() { }

        public BaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.GroupConfiguration())
                        .ApplyConfiguration(new Configurations.PersonConfiguration())
                        .ApplyConfiguration(new Configurations.CalendarConfiguration())
                        .ApplyConfiguration(new Configurations.HolidayConfiguration());
        }
    }
}
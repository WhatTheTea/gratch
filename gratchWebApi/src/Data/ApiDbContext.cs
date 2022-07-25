using Microsoft.EntityFrameworkCore;

namespace gratch.Api.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<GroupModel> Groups { get; set; }
        public DbSet<PersonModel> People { get; set; }
        public DbSet<CalendarModel> Calendars { get; set; }
        public DbSet<HolidayModel> Holidays { get; set; }
#pragma warning disable CS8618
        public ApiDbContext(DbContextOptions options) : base(options)
        {
            
        }
#pragma warning restore CS8618
    }
}
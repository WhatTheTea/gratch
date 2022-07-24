using Microsoft.EntityFrameworkCore;

namespace gratch.Api.Data
{
    public class ApiDbContext : DbContext 
    {
        public DbSet<Dummy> Dummies { get; set; }

#pragma warning disable CS8618
        public ApiDbContext(DbContextOptions options) : base(options)
        {
            
        }
#pragma warning restore CS8618
    }
}
using Microsoft.EntityFrameworkCore;
using gratch.Library;

namespace gratch.Api.Data
{
    public class ApiDbContext : gratch.Library.DAL.BaseContext 
    {
#pragma warning disable CS8618
        public ApiDbContext(DbContextOptions options) : base(options)
        {
            
        }
#pragma warning restore CS8618
    }
}
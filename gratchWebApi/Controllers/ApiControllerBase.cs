using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gratch.Api.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public abstract class ApiControllerBase : ControllerBase
        {
            protected Api.Data.ApiDbContext _dbContext;

            public ApiControllerBase(gratch.Api.Data.ApiDbContext dbContext)
            {
                _dbContext = dbContext;
                _dbContext.Database.EnsureCreated();
            }

        }
}
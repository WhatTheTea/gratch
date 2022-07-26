using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using gratch.Api.Data;

namespace gratch.Api.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public abstract class ApiControllerBase : ControllerBase
        {
            protected ApiDbContext _dbContext;

            public ApiControllerBase(ApiDbContext dbContext)
            {
                _dbContext = dbContext;
                _dbContext.Database.EnsureCreated();
            }

        }
}
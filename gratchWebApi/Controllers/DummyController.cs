using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gratch.Api.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class DummyController : ControllerBase
        {
            private Api.Data.ApiDbContext _dbContext;

            public DummyController(gratch.Api.Data.ApiDbContext dbContext)
            {
                _dbContext = dbContext;
                _dbContext.Database.EnsureCreated();

                _dbContext.Dummies.Add(new(0, "kek"));
                _dbContext.SaveChanges();
            }
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Data.Dummy>>> Get()
            {
                try
                {
                    return await Task.FromResult<ActionResult<IEnumerable<Data.Dummy>>>(_dbContext.Dummies);
                }
                catch (System.Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }
}
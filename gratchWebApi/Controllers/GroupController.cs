using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using gratch.Library;

namespace gratch.Api.Controllers
{
        public class GroupController : ApiControllerBase
        {
            public GroupController(gratch.Api.Data.ApiDbContext dbContext) : base(dbContext)
            {

            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Group>?>> GetAll()
            {
                try
                {
                    var query = await _dbContext.Groups.Include(x => x.People)
                                                       .Include(x => x.Calendar)
                                                       .ThenInclude(x => x.Holidays)
                                                       .ToListAsync();
                    ActionResult result = new JsonResult(query);
                    return result ?? NoContent();
                }
                catch (System.Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            
            [HttpGet("{id}")]
            public async Task<ActionResult<Group?>> GetById(int id)
            {
                try
                {
                    var query = await _dbContext.Groups.Include(x => x.People)
                                                       .Include(x => x.Calendar)
                                                       .ThenInclude(x => x.Holidays)
                                                       .FirstOrDefaultAsync(x => x.Id == id);
                    ActionResult result = new JsonResult(query);
                    return result ?? NoContent();
                }
                catch (System.Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            [HttpPatch("{id}")]
            public async Task<ActionResult> Update(int id, [FromBody] Group group)
            {
                try
                {
                    if(id != group.Id) return BadRequest("Ids mismatch");
                    var query = _dbContext.Groups.Update(group);
                    await _dbContext.SaveChangesAsync();
                    return Ok();
                }
                catch (System.Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            [HttpPost]
            public async Task<ActionResult> Create([FromBody] Group group)
            {
                try
                {
                    _dbContext.Groups.Add(group);
                    await _dbContext.SaveChangesAsync();
                    return Ok();
                }
                catch (System.Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult> Delete(int id)
            {
                try
                {
                    var itemToDelete = await _dbContext.Groups.FirstOrDefaultAsync(x => x.Id == id);
                    if(itemToDelete == null) return NoContent();
                    _dbContext.Remove(itemToDelete);
                    await _dbContext.SaveChangesAsync();
                    return Ok();
                }
                catch (System.Exception)
                {
                     return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }
}
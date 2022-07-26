using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using gratch.Api.Data;

namespace gratch.Api.Controllers
{
        public class GroupController : ApiControllerBase
        {
            public GroupController(ApiDbContext dbContext) : base(dbContext)
            {

            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<GroupModel>?>> GetAll()
            {
                try
                {
                    var query = await _dbContext.Groups.Include(x => x.People)
                                                       .Include(x => x.Calendar)
                                                       .ThenInclude(x => x.Holidays)
                                                       .ToListAsync();
                    return query.Any() ? Ok(query) : NoContent();
                }
                catch (System.Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            
            [HttpGet("{id}")]
            public async Task<ActionResult<GroupModel?>> GetById(int id)
            {
                try
                {
                    var query = await _dbContext.Groups.Include(x => x.People)
                                                       .Include(x => x.Calendar)
                                                       .ThenInclude(x => x.Holidays)
                                                       .FirstOrDefaultAsync(x => x.Id == id);
                    return query == null ? NotFound($"Group with id {id} is not found") : Ok(query);
                }
                catch (System.Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            [HttpPatch("{id}")]
            public async Task<ActionResult> Update(int id, [FromBody] GroupModel group)
            {
                try
                {
                    if(id != group.Id) return BadRequest("Ids mismatch");
                    var query = _dbContext.Groups.Update(group);
                    int rowsupdated = await _dbContext.SaveChangesAsync();
                    return Ok("Success! Rows updated: " + rowsupdated);
                }
                catch (System.Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            [HttpPost]
            public async Task<ActionResult> Create([FromBody] GroupModel group)
            {
                try
                {
                    _dbContext.Groups.Add(group);
                    int rowsadded = await _dbContext.SaveChangesAsync();
                    return Ok("Success! Rows added: " + rowsadded);
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
                    int rowsdeleted = await _dbContext.SaveChangesAsync();
                    return Ok("Success! Rows deleted: " + rowsdeleted);
                }
                catch (System.Exception)
                {
                     return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }
}
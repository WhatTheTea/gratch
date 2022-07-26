using Microsoft.EntityFrameworkCore;

namespace gratch.Api.Controllers
{
    using gratch.Api.Data;
    using Microsoft.AspNetCore.Mvc;

    public class PeopleController : ApiControllerBase
    {
        public PeopleController(ApiDbContext dbContext) : base(dbContext)
        {

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonModel>>> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }
        private ActionResult<IEnumerable<PersonModel>> GetAll()
        {
            try
            {
                IEnumerable<PersonModel>? query = _dbContext.People.Include(x => x.Group);
                return query.Any() ? Ok(query) : NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonModel>> GetAsync(int id)
        {
            try
            {
                var query = await _dbContext.People.Include(x => x.Group)
                                                   .FirstOrDefaultAsync(x => x.Id == id);
                return query == null ? NotFound($"Person with id: {id} is not found") : Ok(query);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PersonModel person)
        {
            try
            {
                _dbContext.People.Add(person);
                int newrows = await _dbContext.SaveChangesAsync();
                return Ok("Success! New rows: " + newrows);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }        
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchAsync(int id, [FromBody] PersonModel person)
        {
            try
                {
                    if(id != person.Id) return BadRequest("Ids mismatch");
                    var query = _dbContext.People.Update(person);
                    int changedrows = await _dbContext.SaveChangesAsync();
                    return Ok("Success! Rows changed: " + changedrows);
                }
                catch (System.Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
                {
                    var itemToDelete = await _dbContext.People.FindAsync(id);
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
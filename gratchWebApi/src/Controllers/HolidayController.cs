using Microsoft.EntityFrameworkCore;

namespace gratch.Api.Controllers
{
    using gratch.Api.Data;
    using Microsoft.AspNetCore.Mvc;

    public class HolidayController : ApiControllerBase
    {
        public HolidayController(ApiDbContext dbContext) : base(dbContext)
        {

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HolidayModel>>> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }
        private ActionResult<IEnumerable<HolidayModel>> GetAll()
        {
            try
            {
                IEnumerable<HolidayModel>? query = _dbContext.Holidays.Include(x => x.Calendar);
                return query.Any() ? Ok(query) : NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HolidayModel>> GetAsync(int id)
        {
            try
            {
                var query = await _dbContext.Holidays.Include(x => x.Calendar)
                                                     .FirstOrDefaultAsync(x => x.Id == id);
                return query == null ? NotFound($"Holiday with id: {id} is not found") : Ok(query);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] HolidayModel holiday)
        {
            try
            {
                _dbContext.Holidays.Add(holiday);
                int newrows = await _dbContext.SaveChangesAsync();
                return Ok("Success! New rows: " + newrows);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }        
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchAsync(int id, [FromBody] HolidayModel holiday)
        {
            try
                {
                    if(id != holiday.Id) return BadRequest("Ids mismatch");
                    var query = _dbContext.Holidays.Update(holiday);
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
                    var itemToDelete = await _dbContext.Holidays.FindAsync(id);
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
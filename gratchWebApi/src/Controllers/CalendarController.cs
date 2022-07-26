using Microsoft.EntityFrameworkCore;

namespace gratch.Api.Controllers
{
    using gratch.Api.Data;
    using Microsoft.AspNetCore.Mvc;

    public class CalendarController : ApiControllerBase
    {
        public CalendarController(ApiDbContext dbContext) : base(dbContext)
        {

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalendarModel>>> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }
        private ActionResult<IEnumerable<CalendarModel>> GetAll()
        {
            try
            {
                IEnumerable<CalendarModel>? query = _dbContext.Calendars.Include(x => x.Group)
                                                                        .Include(x => x.Holidays);
                return query.Any() ? Ok(query) : NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CalendarModel>> GetAsync(int id)
        {
            try
            {
                var query = await _dbContext.Calendars.Include(x => x.Group)
                                                      .Include(x => x.Holidays)
                                                      .FirstOrDefaultAsync(x => x.Id == id);
                return query == null ? NotFound($"Calendar with id: {id} is not found") : Ok(query);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CalendarModel calendar)
        {
            try
            {
                _dbContext.Calendars.Add(calendar);
                int newrows = await _dbContext.SaveChangesAsync();
                return Ok("Success! New rows: " + newrows);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchAsync(int id, [FromBody] CalendarModel calendar)
        {
            try
            {
                if (id != calendar.Id) return BadRequest("Ids mismatch");
                var query = _dbContext.Calendars.Update(calendar);
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
                if (itemToDelete == null) return NoContent();
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
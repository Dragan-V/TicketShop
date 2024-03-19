using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TShop.Data;
using TShop.Models;

namespace TShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreShowsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TheatreShowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TheatreShows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TheatreShow>>> GetTheatreShow()
        {
            return await _context.TheatreShow.ToListAsync();
        }

        // GET: api/TheatreShows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TheatreShow>> GetTheatreShow(Guid id)
        {
            var theatreShow = await _context.TheatreShow.FindAsync(id);

            if (theatreShow == null)
            {
                return NotFound();
            }

            return theatreShow;
        }

        // PUT: api/TheatreShows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTheatreShow(Guid id, TheatreShow theatreShow)
        {
            if (id != theatreShow.Id)
            {
                return BadRequest();
            }

            _context.Entry(theatreShow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TheatreShowExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TheatreShows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TheatreShow>> PostTheatreShow(TheatreShow theatreShow)
        {
            _context.TheatreShow.Add(theatreShow);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTheatreShow", new { id = theatreShow.Id }, theatreShow);
        }

        // DELETE: api/TheatreShows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheatreShow(Guid id)
        {
            var theatreShow = await _context.TheatreShow.FindAsync(id);
            if (theatreShow == null)
            {
                return NotFound();
            }

            _context.TheatreShow.Remove(theatreShow);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TheatreShowExists(Guid id)
        {
            return _context.TheatreShow.Any(e => e.Id == id);
        }
    }
}

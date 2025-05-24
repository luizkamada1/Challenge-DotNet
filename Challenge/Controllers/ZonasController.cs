using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Challenge.Data;
using Challenge.Models;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZonasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ZonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/zonas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zona>>> GetAll()
        {
            return await _context.Zonas.Include(z => z.Patio).ToListAsync();
        }

        // GET: api/zonas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zona>> GetById(int id)
        {
            var zona = await _context.Zonas
                .Include(z => z.Patio)
                .FirstOrDefaultAsync(z => z.Id == id);

            if (zona == null)
                return NotFound();

            return zona;
        }

        // POST: api/zonas
        [HttpPost]
        public async Task<ActionResult<Zona>> Create(Zona zona)
        {
            _context.Zonas.Add(zona);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = zona.Id }, zona);
        }

        // PUT: api/zonas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Zona zona)
        {
            if (id != zona.Id)
                return BadRequest();

            _context.Entry(zona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Zonas.Any(z => z.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/zonas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var zona = await _context.Zonas.FindAsync(id);
            if (zona == null)
                return NotFound();

            _context.Zonas.Remove(zona);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

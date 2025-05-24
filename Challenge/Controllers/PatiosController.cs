using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Challenge.Data;
using Challenge.Models;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatiosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/patios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patio>>> GetAll()
        {
            return await _context.Patios.ToListAsync();
        }

        // GET: api/patios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patio>> GetById(int id)
        {
            var patio = await _context.Patios.FindAsync(id);

            if (patio == null)
                return NotFound();

            return patio;
        }

        // POST: api/patios
        [HttpPost]
        public async Task<ActionResult<Patio>> Create(Patio patio)
        {
            _context.Patios.Add(patio);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = patio.Id }, patio);
        }

        // PUT: api/patios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Patio patio)
        {
            if (id != patio.Id)
                return BadRequest();

            _context.Entry(patio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Patios.Any(p => p.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/patios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var patio = await _context.Patios.FindAsync(id);
            if (patio == null)
                return NotFound();

            _context.Patios.Remove(patio);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

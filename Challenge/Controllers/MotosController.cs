using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Challenge.Data;
using Challenge.Models;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MotosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/motos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moto>>> GetAll()
        {
            return await _context.Motos.Include(m => m.Zona).ToListAsync();
        }

        // GET: api/motos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Moto>> GetById(int id)
        {
            var moto = await _context.Motos.Include(m => m.Zona).FirstOrDefaultAsync(m => m.Id == id);
            if (moto == null)
                return NotFound();

            return moto;
        }

        // GET: api/motos/status/Ativa
        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<Moto>>> GetByStatus(string status)
        {
            return await _context.Motos
                .Where(m => m.StatusMoto.ToLower() == status.ToLower())
                .ToListAsync();
        }

        // GET: api/motos/zona/2
        [HttpGet("zona/{zonaId}")]
        public async Task<ActionResult<IEnumerable<Moto>>> GetByZona(int zonaId)
        {
            return await _context.Motos
                .Where(m => m.ZonaId == zonaId)
                .ToListAsync();
        }

        // POST: api/motos
        [HttpPost]
        public async Task<ActionResult<Moto>> Create(Moto moto)
        {
            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = moto.Id }, moto);
        }

        // PUT: api/motos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Moto moto)
        {
            if (id != moto.Id)
                return BadRequest();

            _context.Entry(moto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Motos.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/motos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null)
                return NotFound();

            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

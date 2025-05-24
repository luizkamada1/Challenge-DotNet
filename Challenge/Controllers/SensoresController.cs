using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Challenge.Data;
using Challenge.Models;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SensoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/sensores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorRFID>>> GetAll()
        {
            return await _context.Sensores.Include(s => s.Zona).ToListAsync();
        }

        // GET: api/sensores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SensorRFID>> GetById(int id)
        {
            var sensor = await _context.Sensores.Include(s => s.Zona).FirstOrDefaultAsync(s => s.Id == id);

            if (sensor == null)
                return NotFound();

            return sensor;
        }

        // POST: api/sensores
        [HttpPost]
        public async Task<ActionResult<SensorRFID>> Create(SensorRFID sensor)
        {
            _context.Sensores.Add(sensor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = sensor.Id }, sensor);
        }

        // PUT: api/sensores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SensorRFID sensor)
        {
            if (id != sensor.Id)
                return BadRequest();

            _context.Entry(sensor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Sensores.Any(s => s.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/sensores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sensor = await _context.Sensores.FindAsync(id);
            if (sensor == null)
                return NotFound();

            _context.Sensores.Remove(sensor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

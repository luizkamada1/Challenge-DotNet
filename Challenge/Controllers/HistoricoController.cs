using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Challenge.Data;
using Challenge.Models;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoricoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HistoricoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/historico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricoMovimentacao>>> GetAll()
        {
            return await _context.Historicos
                .Include(h => h.Moto)
                .Include(h => h.Zona)
                .Include(h => h.Sensor)
                .ToListAsync();
        }

        // GET: api/historico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoMovimentacao>> GetById(int id)
        {
            var historico = await _context.Historicos
                .Include(h => h.Moto)
                .Include(h => h.Zona)
                .Include(h => h.Sensor)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (historico == null)
                return NotFound();

            return historico;
        }

        // GET: api/historico/moto/1001
        [HttpGet("moto/{motoId}")]
        public async Task<ActionResult<IEnumerable<HistoricoMovimentacao>>> GetByMotoId(int motoId)
        {
            return await _context.Historicos
                .Where(h => h.MotoId == motoId)
                .Include(h => h.Zona)
                .Include(h => h.Sensor)
                .ToListAsync();
        }

        // POST: api/historico
        [HttpPost]
        public async Task<ActionResult<HistoricoMovimentacao>> Create(HistoricoMovimentacao historico)
        {
            _context.Historicos.Add(historico);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = historico.Id }, historico);
        }
    }
}

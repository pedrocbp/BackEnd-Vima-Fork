using Microsoft.AspNetCore.Mvc;
using VimaV2.Database;
using VimaV2.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VimaV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly VimaV2DbContext _context;

        public ContatoController(VimaV2DbContext context)
        {
            _context = context;
        }

        // GET: /api/contato
        [HttpGet]
        public async Task<IActionResult> GetContatos()
        {
            var contatos = await _context.Contatos.ToListAsync();
            return Ok(contatos);
        }

        // POST: /api/contato
        [HttpPost("save")]
        public async Task<IActionResult> SaveContato([FromBody] Contato contato)
        {
           
                _context.Contatos.Add(contato);
                await _context.SaveChangesAsync();
                return Created($"/api/contato/{contato.Id}", contato);
        }
    }
}

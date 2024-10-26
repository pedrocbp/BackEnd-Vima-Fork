using Microsoft.AspNetCore.Mvc;
using VimaV2.Database;
using VimaV2.Models; // Ajuste o namespace para a classe User

namespace VimaV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly VimaV2DbContext _dbContext;

        public UsuariosController(VimaV2DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/usuarios
        [HttpGet]
        public IActionResult GetUsuarios()
        {
            var usuarios = _dbContext.Usuarios.ToList();
            return Ok(usuarios);
        }

        // POST: api/usuario
        [HttpPost]
        public IActionResult CreateUsuario([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null.");
            }

            _dbContext.Usuarios.Add(user);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetUsuarioById), new { id = user.Id }, user);
        }

        // GET: api/usuario/{id}
        [HttpGet("{id}")]
        public IActionResult GetUsuarioById(int id)
        {
            var user = _dbContext.Usuarios.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}

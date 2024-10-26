using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VimaV2.Models;  // Ajuste o namespace para o modelo de User
using VimaV2.Database;
using VimaV2.Util;

namespace VimaV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly VimaV2DbContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthController(VimaV2DbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Senha))
            {
                return BadRequest("Email e senha são obrigatórios.");
            }

            var usuarioEncontrado = await _dbContext.Usuarios
                .FirstOrDefaultAsync(u => u.Email == user.Email);

            if (usuarioEncontrado == null || usuarioEncontrado.Senha != user.Senha)
            {
                return BadRequest("Email ou senha incorretos.");
            }

            var token = JwtTools.GerarToken(usuarioEncontrado, _configuration);

            return Ok(new { token });
        }
    }
}

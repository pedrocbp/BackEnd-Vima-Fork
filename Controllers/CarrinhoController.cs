using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VimaV2.Database;

namespace VimaV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhoController : ControllerBase
    {
        private readonly VimaV2DbContext _dbContext;

        public CarrinhoController(VimaV2DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST: api/carrinho/criar
        [HttpPost("criar")]
        public async Task<IActionResult> CreateCarrinho([FromBody] Carrinho carrinho)
        {
            if (carrinho == null)
            {
                return BadRequest("Carrinho não pode ser nulo.");
            }

            _dbContext.Carrinhos.Add(carrinho);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarrinhoById), new { id = carrinho.Id }, carrinho);
        }

        // PUT: api/carrinho/update/{id}
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCarrinho(int id, [FromBody] Carrinho carrinho)
        {
            try
            {
                var carrinhoEncontrado = await _dbContext.Carrinhos.FindAsync(id);
                if (carrinhoEncontrado == null)
                {
                    return NotFound();
                }

                // Atualiza as propriedades se não forem nulas ou inválidas
                if (carrinho.Quantidade != default(int) && carrinho.Quantidade > 0)
                {
                    carrinhoEncontrado.Quantidade = carrinho.Quantidade;
                }

                if (!string.IsNullOrWhiteSpace(carrinho.Tamanhos))
                {
                    carrinhoEncontrado.Tamanhos = carrinho.Tamanhos;
                }

                if (!string.IsNullOrWhiteSpace(carrinho.Product))
                {
                    carrinhoEncontrado.Product = carrinho.Product;
                }

                if (carrinho.Preco != default(decimal) && carrinho.Preco > 0)
                {
                    carrinhoEncontrado.Preco = carrinho.Preco;
                }

                if (!string.IsNullOrWhiteSpace(carrinho.ImageURL))
                {
                    carrinhoEncontrado.ImageURL = carrinho.ImageURL;
                }

                await _dbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // DELETE: api/carrinho/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteCarrinho(int id)
        {
            var carrinhoEncontrado = _dbContext.Carrinhos.Find(id);
            if (carrinhoEncontrado == null)
            {
                return NotFound();
            }

            _dbContext.Carrinhos.Remove(carrinhoEncontrado);
            _dbContext.SaveChanges();

            return NoContent();
        }

        // GET: api/carrinho/get
        [HttpGet("get")]
        public async Task<IActionResult> GetCarrinhos()
        {
            var carrinho = await _dbContext.Carrinhos.ToListAsync();
            return Ok(carrinho);
        }

        // GET: api/carrinho/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarrinhoById(int id)
        {
            var carrinho = await _dbContext.Carrinhos.FindAsync(id);
            if (carrinho == null)
            {
                return NotFound();
            }

            return Ok(carrinho);
        }
    }
}

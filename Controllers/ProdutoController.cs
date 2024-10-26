using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VimaV2.Database;
using VimaV2.Models;  // Ajuste o namespace para o modelo Produto

namespace VimaV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly VimaV2DbContext _dbContext;

        public ProdutosController(VimaV2DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/produtos
        [HttpGet]
        public async Task<IActionResult> GetProdutos()
        {
            var produtos = await _dbContext.Produtos.ToListAsync();
            return Ok(produtos);
        }

        // POST: api/produto/criar
        [HttpPost("criar")]
        public async Task<IActionResult> CreateProduto([FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest("Produto não pode ser nulo.");
            }

            _dbContext.Produtos.Add(produto);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProdutoById), new { id = produto.Id }, produto);
        }

        // GET: api/produto/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdutoById(int id)
        {
            var produto = await _dbContext.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        // DELETE: api/produto/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteProduto(int id)
        {
            var produtoEncontrado = _dbContext.Produtos.Find(id);

            if (produtoEncontrado == null)
            {
                return NotFound();
            }

            _dbContext.Produtos.Remove(produtoEncontrado);
            _dbContext.SaveChanges();

            return NoContent();
        }

        // PUT: api/produto/update/{id}
        [HttpPut("update/{id}")]
        public IActionResult UpdateProduto(int id, [FromBody] Produto produto)
        {
            var produtoEncontrado = _dbContext.Produtos.Find(id);

            if (produtoEncontrado == null)
            {
                return NotFound();
            }

            produto.Id = id; // Mantém o Id original
            _dbContext.Entry(produtoEncontrado).CurrentValues.SetValues(produto);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}

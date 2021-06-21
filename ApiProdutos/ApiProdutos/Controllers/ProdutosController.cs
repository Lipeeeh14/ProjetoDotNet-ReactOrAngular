using Microsoft.AspNetCore.Mvc;
using ApiProdutos.Domain.Models;
using ApiProdutos.Domain.Services;
using Microsoft.AspNetCore.Authorization;

namespace ApiProdutos.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        // GET: api/Produtos
        [HttpGet]
        public IActionResult GetProdutos()
        {
            return Ok(_produtoService.FindAll());
        }

        // GET: api/Produtos/5
        [HttpGet("find-by-id")]
        public IActionResult GetProduto([FromQuery] long id)
        {
            var produto = _produtoService.FindById(id);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpGet("find-by-name")]
        public IActionResult GetProdutoByName([FromQuery] string name)
        {
            var produto = _produtoService.FindByName(name);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        [ClaimsAuthorize("Produto", "Incluir")]
        [HttpPost]
        public IActionResult PostProduto([FromBody] Produto produto)
        {
            if (produto == null) return BadRequest();
            return Ok(_produtoService.Create(produto));
        }

        [ClaimsAuthorize("Produto","Editar")]
        [HttpPut("put-by-id")]
        public IActionResult PutProduto([FromQuery] long id, [FromBody] Produto produto)
        {
            if (Exists(id)) return Ok(_produtoService.Update(id, produto));
            return BadRequest();
        }

        [ClaimsAuthorize("Produto", "Excluir")]
        [HttpDelete("delete-by-id")]
        public IActionResult DeleteProduto(long id)
        {
            if (Exists(id))
            {
                _produtoService.Delete(id);
                return NoContent();
            }
            return BadRequest();
        }

        private bool Exists(long id)
        {
            var produto = _produtoService.FindById(id);
            if (produto == null) return false;
            return true;
        }
    }
}

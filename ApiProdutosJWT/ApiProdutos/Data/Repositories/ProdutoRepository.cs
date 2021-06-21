using ApiProdutos.Data.MySQL;
using ApiProdutos.Data.Repositories.Generic;
using ApiProdutos.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiProdutos.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MySQLContext context) : base(context) { }

        public List<Produto> FindByName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return _context.Produtos.Where(
                    p => p.Nome.Contains(name)).ToList();
            }
            return null;
        }
    }
}

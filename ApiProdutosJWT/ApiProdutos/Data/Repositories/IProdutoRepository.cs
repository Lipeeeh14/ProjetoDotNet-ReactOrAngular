using ApiProdutos.Data.Repositories.Generic;
using ApiProdutos.Domain.Models;
using System.Collections.Generic;

namespace ApiProdutos.Data.Repositories
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        List<Produto> FindByName(string name);
    }
}

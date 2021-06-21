using ApiProdutos.Domain.Models;
using System.Collections.Generic;

namespace ApiProdutos.Domain.Services
{
    public interface IProdutoService
    {
        List<Produto> FindAll();
        Produto FindById(long id);
        List<Produto> FindByName(string name);
        Produto Create(Produto produto);
        Produto Update(long id, Produto produto);
        void Delete(long id);
    }
}

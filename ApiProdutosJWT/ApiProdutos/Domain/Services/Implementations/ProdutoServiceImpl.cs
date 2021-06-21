using ApiProdutos.Data.Repositories;
using ApiProdutos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProdutos.Domain.Services.Implementations
{
    public class ProdutoServiceImpl : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoServiceImpl(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public List<Produto> FindAll()
        {
            return _repository.FindAll();
        }

        public Produto FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<Produto> FindByName(string name)
        {
            return _repository.FindByName(name);
        }

        public Produto Create(Produto produto)
        {
            return _repository.Create(produto);
        }

        public Produto Update(long id, Produto produto)
        {
            return _repository.Update(id, produto);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}

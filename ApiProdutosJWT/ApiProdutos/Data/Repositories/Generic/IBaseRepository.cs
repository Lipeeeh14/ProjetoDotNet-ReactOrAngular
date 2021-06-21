using ApiProdutos.Domain.Models;
using System.Collections.Generic;

namespace ApiProdutos.Data.Repositories.Generic
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        List<T> FindAll();
        T FindById(long id);
        T Create(T item);
        T Update(long id, T item);
        void Delete(long id);
    }
}

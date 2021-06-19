using ApiProdutos.Data.MySQL;
using ApiProdutos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProdutos.Data.Repositories.Generic
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected MySQLContext _context;

        private DbSet<T> dataset;

        public BaseRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(i => i.Id.Equals(id));
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Update(long id, T item)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
            if(result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}

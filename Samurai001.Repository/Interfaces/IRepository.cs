using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai001.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        //Task Delete(T entity);
        public Task<IEnumerable<T>> GetAll();
        public Task<T?> GetById(int id);
        public Task<T> Create(T entity);
        public Task<bool> Delete(T entity);

    }
}

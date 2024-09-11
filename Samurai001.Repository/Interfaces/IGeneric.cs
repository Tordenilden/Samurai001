using Samurai001.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai001.Repository.Interfaces
{
    public interface IGeneric<T> 
    {
        public List<Samurai> getALL();
        public IEnumerable<T> getAll();
        public T getById(int id);
    }
}

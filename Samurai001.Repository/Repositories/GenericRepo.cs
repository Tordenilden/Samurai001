using Microsoft.EntityFrameworkCore;
using Samurai001.Repository.Interfaces;
using Samurai001.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai001.Repository.Repositories
{
    public class GenericRepo<T> : IGeneric<T> where T : class, IEntity
    {
        public DatabaseContext context { get; set; }
        public GenericRepo(DatabaseContext context)
        {
            this.context = context;
        }
        public List<Samurai> getALL()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> getAll()
        { 
            return context.Set<T>().ToList();
        }

        public T getById(int id)
        {
            //return context.Set<T>().Find(id);
            return context.Set<T>().FirstOrDefault(g=>g.Id == id);
           
        }
    }
}

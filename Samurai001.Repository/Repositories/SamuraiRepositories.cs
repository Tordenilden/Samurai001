using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Samurai001.Repository.Interfaces;
using Samurai001.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai001.Repository.Repositories
{
    /// <summary>
    /// This Inherit from Interface
    /// Use DatabaseContext as a property
    /// </summary>
    public class SamuraiRepositories : ISamuraiRepository
    {
        public DatabaseContext context { get; set; }
        public SamuraiRepositories(DatabaseContext database) { this.context = database; }

        public Samurai Create(Samurai samurai)
        {
            context.Add(samurai);
            context.SaveChanges();
            return samurai;
        }

        public Samurai CreateComplex(Samurai samurai)
        {
            throw new NotImplementedException();
        }

        public List<Samurai> GetAll()
        {
            return context.Samurai.ToList();
        }

        public List<Samurai> GetAllAndHorsie()
        {
            return context.Samurai.Include(obj => obj.Horse).ToList();
        }

        public List<Samurai> GetAllAndHorsieWhere(string name)
        {
            return context.Samurai.Include(obj=>obj.Horse).Where(h => h.Name == name).ToList();
        }

        public Samurai? GetById(int id)
        {
            return context.Samurai.FirstOrDefault(x => x.Id == id);
        }

        public List<Samurai> GetAllRelations()
        {
            var result = context.Samurai.Include(s=>s.Horse).Include(s=>s.Battles).ToList();
            return result;
        }

        public bool Delete(int samuraiId)
        {
            var result = context.Samurai.FirstOrDefault(x => x.Id == samuraiId);
            if (result != null)
            {
                context.Samurai.Remove(result);
                context.SaveChanges();
            }
            return result != null;
        }
    }
}

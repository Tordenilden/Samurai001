using Samurai001.Repository.Interfaces;
using Samurai001.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai001.Repository.Repositories
{
    public class HorseRepositories : IHorseRepository
    {
        public DatabaseContext context { get; set; }
        public HorseRepositories(DatabaseContext database)
        {
            context = database;
        }
        public Horse Create(Horse horse)
        {
            context.Horse.Add(horse);
            context.SaveChanges();
            return horse;
        }

        public bool Delete(int horseId)
        {
            var result = context.Horse.FirstOrDefault(h=>h.Id == horseId);
            if (result != null) { context.Horse.Remove(result); context.SaveChanges(); }
            return result != null;
        }

        public List<Horse> GetAll()
        {
            return context.Horse.ToList();
        }

        public Horse? GetById(int id)
        {
            return context.Horse.FirstOrDefault(h => h.Id == id);
        }
    }
}

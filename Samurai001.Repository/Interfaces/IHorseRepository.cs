using Samurai001.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai001.Repository.Interfaces
{
    internal interface IHorseRepository
    {
        Horse Create(Horse horse);
        List<Horse> GetAll();
        Horse? GetById(int id);
        bool Delete(int horseId);
    }
}

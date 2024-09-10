using Samurai001.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai001.Repository.Interfaces
{
    internal interface ISamuraiRepository
    {
        Samurai Create(Samurai samurai);
        Samurai CreateComplex(Samurai samurai);
        List<Samurai> GetAll();
        List<Samurai> GetAllAndHorsie();
        List<Samurai> GetAllAndHorsieWhere(string name);
        Samurai? GetById(int id);
        List<Samurai> GetAllRelations();
        bool Delete(int samuraiId);

    }
}

using Samurai001.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai001.Repository.Interfaces
{
    internal interface IBattleRepository
    {
        Battle Create(Battle battle);
        List<Battle> GetAll();
        Battle? GetById(int battleId);
        bool Delete(int battleId);
    }
}

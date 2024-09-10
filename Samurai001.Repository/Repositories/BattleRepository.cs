using Microsoft.EntityFrameworkCore;
using Samurai001.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai001.Repository.Repositories
{
    public class BattleRepository : ITirsdag
    {
        // db - all methods
        private DatabaseContext context;
        public BattleRepository(DatabaseContext context)
        {
            this.context = context;
        }





        
        public List<Samurai> getAll()
        {
            //"select *    FROM t1, t2 where pk = fk"
            var result = context.Samurai.Include((samuraiObj) => samuraiObj.Battles).ToList();
            return result;
        } 
        public IEnumerable<Samurai> getAllWhere()
        {
            //"select *    FROM t1, t2 where pk = fk"
            var result = context.Samurai.Include((samuraiObj) => samuraiObj.Battles)
                .Where((obj) => obj.Name == "Bo") // WHy ToList()??                
              .ToList();
            return result;
        }

        // getall samuWithBattles
        // getallWhere momo slår Jakob


    }
}

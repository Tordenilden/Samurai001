using Samurai001.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai001.Repository.Models
{
    public class Battle : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public List<Samurai> Samurais { get; set; } = new List<Samurai>();
        //public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        // public List<BattleSamurai> BattleSamurais { get; set; } = new List<BattleSamurai>();
    }
}

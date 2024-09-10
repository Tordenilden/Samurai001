using Samurai001.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Samurai001.Repository.Models
{
    public class Horse : IEntity
    {
        public int Id { get; set; } // PK
        public string name { get; set; }
        public Horse(){ name = "";}
        public Horse(string color)
        {
            name = color;
        }

        // If I had a List or Model I would not have in "Swagger"
        // [JSONIgnore] and ? in the Property
        //[JsonIgnore]
        //public List<Samurai>? SamuraiList { get; set; } = new List<Samurai>();

    }

}


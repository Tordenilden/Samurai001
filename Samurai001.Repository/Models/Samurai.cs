using Samurai001.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai001.Repository.Models
{    
    public class Samurai : IEntity
    {
    public int Id { get; set; } 
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public int Age { get; set; }
    //version 6.0
    public List<Battle> Battles { get; set; } = new List<Battle>();
    //version 5.0
    //public List<BattleSamurai> BattleSamurais { get; set; } = new List<BattleSamurai>();
    //public List<Horse> Horses { get; set; } = new List<Horse>();
    public int HorseId { get; set; } // FK to Samurai Table
    public Horse Horse { get; set; }  // Navigation property = new Horse();
}
}

///// <summary>
///// 1) Create Models
///// 2) Install Packages (3-4)
///// 2.1) Microsoft.EntityFrameworkCore.Design
///// 2.1) Microsoft.EntityFrameworkCore.SqlServer
///// 2.1) Microsoft.EntityFrameworkCore.Tools
///// 2.1) Microsoft.EntityFrameworkCore
///// 3) Create DatabaseContext class
///// 4) Program.cs add our Database service and connection string
///// 5) go to console => add-migration name
///// 5) go to console => database-update
///// 6) Done
///// 7) If the F.. S.. N.. W.. Then activate the DI in Program.cs....
///// 8)
///// 
///// 
///// 
///// EntityFramework works with PK.. int Id or int ClassName+Id 
///// 
///// </summary>
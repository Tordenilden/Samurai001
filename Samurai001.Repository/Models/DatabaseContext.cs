using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Samurai001.Repository.Models
{
    public class DatabaseContext : DbContext
    {
        string horseColor = "blabla";
        //Horse myhorse = new Horse("");
        // 2 c_tor we start with one....
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Samurai> Samurai { get; set; }
        public DbSet<Horse> Horse { get; set; }
        public DbSet<Battle> Battle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //    //    //#region skrald

        //    //    //    //// Configure many-to - many relationship
        //    //    //    ////modelBuilder.Entity<BattleSamurai>()
        //    //    //    ////    .HasKey(pc => new { pc.SamuraiId, pc.BattleId });

        //    //    //    ////modelBuilder.Entity<BattleSamurai>()
        //    //    //    ////    .HasOne(pc => pc.Samurai)
        //    //    //    ////    .WithMany(p => p.BattleSamurais)
        //    //    //    ////    .HasForeignKey(pc => pc.SamuraiId);

        //    //    //    ////modelBuilder.Entity<BattleSamurai>()
        //    //    //    ////    .HasOne(pc => pc.Battle)
        //    //    //    ////    .WithMany(c => c.BattleSamurais)
        //    //    //    ////    .HasForeignKey(pc => pc.BattleId);

        //    //    //    //#endregion skrald
        //    //    //    ///*****************************************************************************************/
        //    //    //    ///*****************************************************************************************/
        //    //    //    ///*****************************************************************************************/

        //    Horse horse1 = new Horse("Tarok") { Id = 1 };
        //    Horse horse2 = new Horse("Fido") { Id = 2 };

        //    Samurai sam1 = new Samurai { Id = 1, Age = 20, Name = "Ulla Skallesmækker", Description = "This is serios", HorseId = 1 };
        //    Samurai sam2 = new Samurai { Id = 2, Age = 20, Name = "Ulla BrainFLuid", Description = "This is serios" };

        //    modelBuilder.Entity<Horse>().HasData(horse1);
        //    modelBuilder.Entity<Samurai>().HasData(sam1);
            // modelBuilder.Entity<Samurai>().HasData(sam2); // Er en fejl The INSERT statement conflicted with the FOREIGN KEY constraint

            ////sam1.Horse = horse1;
            ////sam1.HorseId = 1;
            ////sam2.Horse = horse2;

            //// STEP 3 BATTLE, change relations inside Samurai and Battle
            //Battle battle1 = new Battle { Id = 100, Name = "Imperious", Description = "Really bad", start = new DateTime(2024, 04, 16), end = new DateTime(2024, 04, 18) };
            //Battle battle2 = new Battle
            //{
            //    Id = 200,
            //    Name = "FUnny",
            //    Description = "Really bad",
            //    start = new DateTime(2024, 03, 16),
            //    end = new DateTime(2024, 04, 18)
            //};
            //modelBuilder.Entity<Battle>().HasData(battle1);

            //#region ManyToManySeed Battle and Samurai
            //modelBuilder.Entity<Samurai>()
            //                    .HasMany(p => p.Battles)
            //                    .WithMany(t => t.Samurais)
            //                    .UsingEntity<Dictionary<string, object>>(
            //                        "BattleSamurai",
            //                        r => r.HasOne<Battle>().WithMany().HasForeignKey("BattlesId"),
            //                        l => l.HasOne<Samurai>().WithMany().HasForeignKey("SamuraisId"),
            //                        je =>
            //                        {
            //                            je.HasKey("BattlesId", "SamuraisId");
            //                            je.HasData(
            //                                new { SamuraisId = 1, BattlesId = 100 });
            //                            //,
            //                            //new { PostId = 1, TagId = "informative" },
            //                            //new { PostId = 2, TagId = "classic" },
            //                            //new { PostId = 3, TagId = "opinion" },
            //                            //new { PostId = 4, TagId = "opinion" },
            //                            //new { PostId = 4, TagId = "informative" });
            //                        });
            //    #endregion




            //    //    Samurai sam3 = new Samurai { SamuraiId = 2, Age = 20, Name = "Ulla BrainFLuid", Description = "This is serios", HorseId=2 };
            //    //    Samurai sam4 = new Samurai { SamuraiId = 3, Age = 20, Name = "Ado", Description = "This is serios", HorseId=3 };
            //    //    Samurai sam5 = new Samurai { SamuraiId = 4, Age = 20, Name = "Shadow", Description = "This is serios", HorseId=4 };

            //    //    Horse horse3 = new Horse("Black") { HorseId = 3 };
            //    //    Horse horse4 = new Horse("Svend") { HorseId = 4 };
            //    //    Horse horse5 = new Horse("Tulle") { HorseId = 5 };

            //    //    modelBuilder.Entity<Horse>().HasData(horse2);
            //    //    modelBuilder.Entity<Horse>().HasData(horse3);
            //    //    modelBuilder.Entity<Horse>().HasData(horse4);
            //    //    modelBuilder.Entity<Horse>().HasData(horse5);
            //    //    modelBuilder.Entity<Samurai>().HasData(sam2);
            //    //    modelBuilder.Entity<Samurai>().HasData(sam3);
            //    //    modelBuilder.Entity<Samurai>().HasData(sam4);
            //    //    modelBuilder.Entity<Battle>().HasData(battle2);


            //    //    //       modelBuilder.Entity<BattleSamurai>().HasData(
            //    //    //new BattleSamurai { BattleId = 100, SamuraiId = 10 },
            //    //    //new BattleSamurai { BattleId = 200, SamuraiId = 10 }
            //    //    //);


            //    //    //modelBuilder.Entity<Battle>().HasData(battle2);
            //    //    //sam1.Battle = new List<Battle> { battle1 };
            //    //    //modelBuilder.Entity<Samurai>().HasData(sam1);
            //    //    ////battle1.Samurai = new List<Samurai> { sam1 };


            //    //    //modelBuilder.Entity<Battle>().HasData(battle1);
            //    //    //modelBuilder.Entity<Samurai>().HasData(sam2);
            //    //    //modelBuilder.Entity<Battle>().HasData(battle2);

            //    //    ////modelBuilder.Entity<BattleSamurai>().HasData(
            //    //    ////     new BattleSamurai { BattleId = 100, SamuraiId = 10 },
            //    //    ////     new BattleSamurai { BattleId = 200, SamuraiId = 10 }
            //    //    ////     );
            //    //}


            //}
        }
    }

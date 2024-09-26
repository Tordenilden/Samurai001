using Samurai001.Repository.Models;
using Samurai001.Repository.Interfaces;
using Samurai001.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace Samurai001.Test.RepositoriesTests
{

    /// <summary>
    /// Simulate our database => instans af repo og context og sætte dem sammen
    /// </summary>
    public class SamuraiRepositoriesTest : ISamuraiRepository

    {
        //fields
        private ISamuraiRepository _samurai;
        private DbContextOptions<DatabaseContext> options;
        private DatabaseContext dbcontext;
        //public SamuraiRepositoriesTest(ISamuraiRepository samurai)
        //{
        //    _samurai = samurai;
        //}
        public SamuraiRepositoriesTest() // without DI
        {
            // Danger!! 1)
            List<Samurai> samurais = new List<Samurai> {
            new Samurai(){Age=4,Description="fed", Id = 1, Name= "Kong Gulerod"},
            new Samurai(){Age=14,Description="tynd", Id = 2, Name= "Kong leverpostej"},
            new Samurai(){Age=24,Description="fluffyyy", Id = 3, Name= "Kong tomatmad"},
        };
            //Danger!! 3)
            options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "Darkside") // DatabaseName skal vist nok være forskelligt
                 .Options;
            dbcontext = new DatabaseContext(options);
            //dbcontext.Database.EnsureCreated();
            //dbcontext.Samurai.Add(1)
            // Danger!! 2)
           dbcontext.Samurai.AddRange(samurais);
            dbcontext.SaveChanges();
        }

        // Datagrundlag - det kan være I skal sætte alle data i den enkelte metode...


        [Fact] //XUnit
        public void getAllSamurais()
        {
            //Arrange - Hvad vil jeg teste? => Repo
            SamuraiRepositories repo = new SamuraiRepositories(dbcontext);

            //Act
            var result = repo.GetAll();

            //Assert
            Assert.Equal(3, result.Count());
            Assert.NotNull(result[5]);
        }        
        [Fact]
        public void getAllSamurais_countIsWrong()
        {
            //Arrange - Hvad vil jeg teste? => Repo
            SamuraiRepositories repo = new SamuraiRepositories(dbcontext);

            //Act
            var result = repo.GetAll();

            //Assert
            Assert.Equal(2, result.Count());
        }


        public Samurai Create(Samurai samurai)
        {
            throw new NotImplementedException();
        }

        public Samurai CreateComplex(Samurai samurai)
        {
            throw new NotImplementedException();
        }

        public List<Samurai> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Samurai> GetAllAndHorsie()
        {
            throw new NotImplementedException();
        }

        public List<Samurai> GetAllAndHorsieWhere(string name)
        {
            throw new NotImplementedException();
        }

        public Samurai? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Samurai> GetAllRelations()
        {
            throw new NotImplementedException();
        }

        public bool Delete(int samuraiId)
        {
            throw new NotImplementedException();
        }
    }
}

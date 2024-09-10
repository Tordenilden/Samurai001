using Microsoft.EntityFrameworkCore;
using Samurai001.Repository.Models;
using Samurai001.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai001.Test.RepositoriesTests
{
    public class HorseRepositoriesTest
    {
        private DbContextOptions<DatabaseContext> options;
        private DatabaseContext context;

        public HorseRepositoriesTest()
        {
            options = new DbContextOptionsBuilder<DatabaseContext>()
              .UseInMemoryDatabase(databaseName: "dummyDatabase")
              .Options;

            context = new DatabaseContext(options);
            context.Database.EnsureDeleted();

            context.Horse.Add(new Horse { Id = 1, name = "action" });
            context.Horse.Add(new Horse { Id = 2, name = "hurtig" });
            context.Horse.Add(new Horse { Id = 3, name = "langsom" });
            context.SaveChanges();
        }

        [Fact]
        public async Task GetHorseById_HorseExists()
        {
            // Arrange
            HorseRepositories repository = new HorseRepositories(context);

            // Act
            var result = repository.GetById(1);

            // Assert
            Assert.Equal(1, result.Id);
            Assert.Equal("action", result.name);
        }
        [Fact]
        public async Task GetHorseById_HorseExists_WillFail()
        {
            // Arrange
            HorseRepositories repository = new HorseRepositories(context);

            // Act
            var result = repository.GetById(4);

            // Assert
            Assert.Equal(1, result.Id);
            Assert.Equal("action", result.name);
        }

        //[Fact]
        //public async Task GetGenres()
        //{
        //    // Arrange
        //    HorseRepositories repository = new HorseRepositories(context);

        //    // Act
        //    var genre = await genreRepository.readAllGenres();

        //    // Assert
        //    Assert.Equal(3, genre.Count); // not the best, but it works, I guess.
        //}

    }
}

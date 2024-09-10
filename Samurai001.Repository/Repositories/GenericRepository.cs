using Microsoft.EntityFrameworkCore;
using Samurai001.Repository.Interfaces;
using Samurai001.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Samurai001.Repository.Repositories
{
    /// <summary>
    /// Hvad skal jeg huske??
    /// Hvis vi sammenligner 2 værdier og jeg vil være sikker på der er Id eller Name i en class / classes, hvad kan jeg så gøre?  -svar Interface til at decorere.
    /// Ligesom IEntity
    /// IENtity gør det muligt at kunne tilgå ID
    /// 
    /// Delegates 3 lister med 3 forskellige typer og så vise at man kan benytte den samme metode til alle 3
    /// Jeg skal lige følge op på det her.
    /// 
    /// 
    /// Test:
    /// opret 2 metoder, og så skal de selv lave getall()
    /// så gentage
    /// så næste dag eller om eftermiddagen create
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity
    {
        public DatabaseContext context { get; set; }
        public GenericRepository(DatabaseContext database) { context = database; }

        public async Task<IEnumerable<T>> GetAll()
        {
            var exists = await context.Set<T>().ToListAsync();
            return exists;
        }
        public async Task<T?> GetById(int id)
        {
            var result = await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            return result;
        }

        public async Task<T> Create(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(T entity)
        {
            var exists = await context.Set<T>()!.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (exists != null)
            {
                context.Set<T>().Remove(exists);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }





    }
}

using Microsoft.EntityFrameworkCore;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Data.Repositories
{
    public class Repository <TEntity, TKey> where TEntity:Entity<TKey>
    {
        private readonly ApplicationDbContext applicationDbContext;
        private DbSet<TEntity> entities;

        public Repository (ApplicationDbContext applicationDbContext)
        {
            this.entities = applicationDbContext.Set<TEntity>();
            this.applicationDbContext = applicationDbContext;
        }

        public Task<TEntity> GetById(TKey id)
        {
            return this.entities.FirstOrDefaultAsync(entity => entity.Id.Equals(id));
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            this.entities.Add(entity);
            await this.applicationDbContext.SaveChangesAsync();
            return entity;
        }
    }
}

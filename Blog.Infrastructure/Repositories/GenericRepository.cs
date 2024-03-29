﻿using Blog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Blog.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> 
        where TEntity : BaseModel<TEntity>

    {
        protected DbSet<TEntity> DbSet { get; set; }

        public async Task <IEnumerable<TEntity>> GetAllAsync() => await this.DbSet.ToListAsync();

        public async Task<TEntity?> GetByIdAsync(int id) => throw new NotImplementedException();//await this.DbSet.FirstOrDefaultAsync(x => x.Id == id);

        public void Delete(TEntity model) => this.DbSet.Remove(model);
    }
}

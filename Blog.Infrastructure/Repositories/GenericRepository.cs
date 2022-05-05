using Blog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Blog.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> 
        where TEntity : BaseModel

    {
        private readonly BlogDbContext dbContext;

        public GenericRepository(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.DbSet = dbContext.Set<TEntity>();
        }
        protected DbSet<TEntity> DbSet { get; set; }

        public IEnumerable<TEntity> GetAll() => this.DbSet.ToList();

        public TEntity? GetById(int id) => this.DbSet.FirstOrDefault(x => x.Id == id);

        public void Delete(TEntity model) => this.DbSet.Remove(model);
    }
}

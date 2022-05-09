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

        public async Task <IEnumerable<TEntity>> GetAllAsync() => await this.DbSet.ToListAsync();

        public async Task<TEntity?> GetByIdAsync(int id) => await this.DbSet.FirstOrDefaultAsync(x => x.Id == id);

        public void Delete(TEntity model) => this.DbSet.Remove(model);
    }
}

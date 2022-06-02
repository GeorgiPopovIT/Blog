
namespace Blog.Infrastructure.Repositories
{
    public interface IRepository<TEntity>
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();

        public Task<TEntity?> GetByIdAsync(int id);

        public void Delete(TEntity model);
    }
}

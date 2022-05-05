
namespace Blog.Infrastructure.Repositories
{
    public interface IRepository<TEntity> 
    {
        public IEnumerable<TEntity> GetAll();

        //public TEntity GetById(int id);
    }
}

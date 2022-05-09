using Blog.Core.Contracts;
using Blog.Infrastructure;
using Blog.Infrastructure.Data;
using Blog.Infrastructure.Repositories;

namespace Blog.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> postRepository;
        private readonly BlogDbContext dbContext;

        public PostService(IRepository<Post> postRepository, BlogDbContext dbContext)
        {
            this.postRepository = postRepository;
            this.dbContext = dbContext;
        }

        public void CreatePost()
        {

        }
    }
}

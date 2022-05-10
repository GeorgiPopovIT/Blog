using Blog.Core.Contracts;
using Blog.Core.Models.Posts;
using Blog.Infrastructure;
using Blog.Infrastructure.Data;
using Blog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public async Task<IEnumerable<ListSinglePostModel>> GetAllPosts()
            => await this.dbContext.Posts.AsQueryable()
            .Select(x => new ListSinglePostModel
            {
                Content = x.Content,
                Title = x.Title,
            })
            .ToListAsync();
    }
}

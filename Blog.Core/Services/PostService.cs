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
        private readonly BlogDbContext dbContext;

        public PostService(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreatePost(CreatePostModel model)
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

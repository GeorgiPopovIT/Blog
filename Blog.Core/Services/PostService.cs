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
        private readonly IImageService imageService;

        public PostService(BlogDbContext dbContext, IImageService imageService)
        {
            this.dbContext = dbContext;
            this.imageService = imageService;
        }

        public async Task CreatePost(CreatePostModel model, string userId, string directoryPath)
        {
            var post = new Post
            {
                Content = model.Content,
                Title = model.Title,
                UserId = userId,
            };

            if (model.PhotoPost is not null)
            {
                var image = new Image
                {
                    AddedByUserId = userId,
                    Extension = Path.GetExtension(model.PhotoPost.FileName)
                };

                image.ImageName = image.Id;
                post.Images.Add(image);

                var physicalPath = $"{directoryPath}{image.Id}{image.Extension}";
                await this.imageService.Process(directoryPath, physicalPath, model.PhotoPost);
            }

            await this.dbContext.Posts.AddAsync(post);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ListSinglePostModel>> GetAllPostsAsync()
            => await this.dbContext.Posts.AsNoTracking()
            .Select(x => new ListSinglePostModel
            {
                Content = x.Content,
                Title = x.Title,
                Images = x.Images.Select(i => $"{i.ImageName}{i.Extension}")
            })
            .ToListAsync();
    }
}

using Blog.Core.Contracts;
using Blog.Core.Models.Comments;
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
        private readonly ICommentService commentService;
        private readonly IReactionService reactionService;

        public PostService(BlogDbContext dbContext, IImageService imageService,
            ICommentService commentService)
        {
            this.dbContext = dbContext;
            this.imageService = imageService;
            this.commentService = commentService;
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

                var physicalPath = Path.Combine(directoryPath, $"{image.Id}{image.Extension}");
                await this.imageService.Process(directoryPath, physicalPath, model.PhotoPost);
            }

            await this.dbContext.Posts.AddAsync(post);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SinglePostViewModel>> GetAllPostsAsync(string currentUserId)
            => await this.dbContext.Posts
            .Select(x => new SinglePostViewModel
            {
                PostId = x.Id,
                Content = x.Content,
                Title = x.Title,
                Images = x.Images.Select(i => $"{i.ImageName}{i.Extension}"),
                CreatedOn = x.CreatedOn.ToString(),
                UserFullName = x.User.FullName,
                IsUserReact = this.reactionService.IsUserReact(currentUserId, x.Id)
            })
            .ToListAsync();
    }
}

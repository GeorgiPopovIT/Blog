using Blog.Core.Contracts;
using Blog.Core.Models.Comments;
using Blog.Infrastructure;
using Blog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly BlogDbContext _dbContext;
        public CommentService(BlogDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task CreateComment(CommentInputModel commentToAdd)
        {

            var comment = new Comment
            {
                Content = commentToAdd.Content,
                PostId = commentToAdd.PostId,
                UserId = commentToAdd.UserId
            };

            this._dbContext.Comments.Add(comment);

            await this._dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CommentViewModel>> GetCommentsByPost(int postId)
            => await this._dbContext.Comments
            .AsNoTracking()
            .Where(c => c.PostId == postId)
            .Select(c => new CommentViewModel
            {
                Content = c.Content,
                UserFullName = c.User.FullName
            }).ToListAsync();
    }
}

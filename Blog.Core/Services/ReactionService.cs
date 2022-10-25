using Blog.Core.Contracts;
using Blog.Core.Models.ReactionsInputModel;
using Blog.Infrastructure;
using Blog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.Core.Services
{
    public class ReactionService : IReactionService
    {
        private readonly BlogDbContext _dbContext;

        public ReactionService(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool IsUserReact(string userId, int postId) =>
             this._dbContext.Reactions.Find(userId,postId) != null;
        public async Task AddReaction(ReactionsInputModel reactionToAdd)
        {
            var reaction = new Reaction
            {
                UserId = reactionToAdd.UserId,
                PostId = reactionToAdd.PostId
            };

            await _dbContext.Reactions.AddAsync(reaction);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> GetReactionForPost(int postId)
            => await this._dbContext.Reactions
            .Where(r => r.PostId == postId).CountAsync();

    }
}

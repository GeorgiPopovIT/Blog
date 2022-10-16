using Blog.Core.Models.ReactionsInputModel;

namespace Blog.Core.Contracts
{
    public interface IReactionService
    {
        Task AddReaction(ReactionsInputModel reaction);

        Task<int> GetReactionForPost(int postId);
    }
}

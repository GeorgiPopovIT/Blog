using Blog.Core.Models.ReactionsInputModel;

namespace Blog.Core.Contracts
{
    public interface IReactionService
    {
        bool IsUserReact(string userId, int postId);

        Task AddReaction(ReactionsInputModel reaction);

        Task<int> GetReactionForPost(int postId);
    }
}

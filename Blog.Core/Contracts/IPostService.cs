using Blog.Core.Models.Posts;

namespace Blog.Core.Contracts
{
    public interface IPostService
    {
        Task CreatePost(CreatePostModel model, string userId, string directoryPath);

        Task<IEnumerable<SinglePostViewModel>> GetAllPostsAsync(string currentUserId);
    }
}

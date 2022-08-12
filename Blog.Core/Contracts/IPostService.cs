using Blog.Core.Models.Posts;

namespace Blog.Core.Contracts
{
    public interface IPostService
    {
        public Task CreatePost(CreatePostModel model,string userId,string directoryPath);

        Task<IEnumerable<ListSinglePostModel>> GetAllPostsAsync();
    }
}

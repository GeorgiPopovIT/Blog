using Blog.Core.Models.Posts;

namespace Blog.Core.Contracts
{
    public interface IPostService
    {
        public void CreatePost();

        Task<IEnumerable<ListSinglePostModel>> GetAllPosts();
    }
}

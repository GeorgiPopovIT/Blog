
using Blog.Core.Models.Comments;

namespace Blog.Core.Contracts
{
    public interface ICommentService
    {
        Task CreateComment(CommentInputModel commentToAdd);

        Task<IEnumerable<CommentViewModel>> GetCommentsByPostAsync(int postId);

        Task<int> GetCommentsCountByPost(int postId);
    }
}

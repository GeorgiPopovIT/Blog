
using Blog.Core.Models.Comments;

namespace Blog.Core.Models.Posts
{
    public class ListSinglePostModel
    {
        public string? Title { get; init; }

        public string? CreatedOn { get; init; }

        public string? UserFullName { get; init; }

        public IEnumerable<string>? Images { get; init; }

        public Task<IEnumerable<CommentViewModel>> ? CommentsByPost { get; init; }

        public string? Content { get; init; }
    }
}


using Blog.Core.Models.Comments;

namespace Blog.Core.Models.Posts
{
    public class SinglePostViewModel
    {
        public int PostId { get; init; }
        public string? Title { get; init; }

        public string? CreatedOn { get; init; }

        public string? UserFullName { get; init; }

        public IEnumerable<string>? Images { get; init; }

        //public IEnumerable<CommentViewModel>? CommentsByPost { get; init; }
        public int CommentsCount { get; init; }

        public string? Content { get; init; }
    }
}

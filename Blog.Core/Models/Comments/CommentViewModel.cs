
namespace Blog.Core.Models.Comments
{
    public class CommentViewModel
    {
        public string? Content { get; init; }

        public string? UserFullName { get; init; }

        public DateTime CreatedOn { get; init; }
    }
}

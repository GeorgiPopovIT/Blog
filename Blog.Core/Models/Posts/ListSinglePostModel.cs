
namespace Blog.Core.Models.Posts
{
    public class ListSinglePostModel
    {
        public string? Title { get; set; }

        public string? CreatedOn { get; set; }

        public string? UserFullName { get; set; }

        public IEnumerable<string>? Images { get; set; }

        public string? Content { get; set; }
    }
}

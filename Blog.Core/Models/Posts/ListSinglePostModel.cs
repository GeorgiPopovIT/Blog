
namespace Blog.Core.Models.Posts
{
    public class ListSinglePostModel
    {
        public string? Title { get; set; }

        public IEnumerable<string> Images { get; set; }

        public string Content { get; set; }
    }
}

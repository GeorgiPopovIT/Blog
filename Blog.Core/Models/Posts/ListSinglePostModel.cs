using Microsoft.AspNetCore.Http;

namespace Blog.Core.Models.Posts
{
    public class ListSinglePostModel
    {
        public string? Title { get; set; }

        public IFormFile? PhotoPost { get; set; }

        public string Content { get; set; }
    }
}

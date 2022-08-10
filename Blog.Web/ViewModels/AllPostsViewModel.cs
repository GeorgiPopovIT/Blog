using Blog.Core.Models.Posts;

namespace Blog.Web.ViewModels
{
    public record AllPostsViewModel(IEnumerable<ListSinglePostModel> Posts);
}

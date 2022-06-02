using Blog.Core.Contracts;
using Blog.Core.Models.Posts;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(CreatePostModel model)
        {
            this.postService.CreatePost(model);


            return View();
        }

        public async Task<IActionResult> AllPosts()
        {
            //var posts = this.postService.
            return View();
        }
    }
}

using Blog.Core.Contracts;
using Blog.Core.Models.Posts;
using Blog.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly IWebHostEnvironment environment;

        public PostController(IPostService postService, IWebHostEnvironment environment)
        {
            this.postService = postService;
            this.environment = environment;
        }
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var directorySavePath = this.environment.WebRootPath + AppExtension.DirectoryPathSaveImage;
            var userId = AppExtension.GetUserId(this.User);

            await this.postService.CreatePost(model, userId, directorySavePath);

            ViewData["SuccessAdded"] = "Successfully added post.";

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> AllPosts()
        {
            //var posts = this.postService.
            return View();
        }
    }
}

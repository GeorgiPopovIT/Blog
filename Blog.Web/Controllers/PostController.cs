using Blog.Core.Contracts;
using Blog.Core.Models.Posts;
using Blog.Web.Common;
using Blog.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IPostService postService;
        private readonly IWebHostEnvironment environment;
        private readonly IUserService userService;

        public PostController(IPostService postService, IWebHostEnvironment environment,
            IUserService userService, ICommentService commentService)
        {
            this.postService = postService;
            this.environment = environment;
            this.userService = userService;
            this.commentService = commentService;
        }

        [Authorize]
        public IActionResult CreatePost()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var directorySavePath = Path.Combine(this.environment.WebRootPath, "img", "posts");

            var userId = this.userService.GetUserId(this.User);

            await this.postService.CreatePost(model, userId, directorySavePath);

            ViewData["SuccessAdded"] = "Successfully added post.";

            return RedirectToAction(nameof(AllPosts), "Post");
        }

        [Authorize]
        public async Task<IActionResult> AllPosts()
        {
            var posts =  await this.postService.GetAllPostsAsync();

            return View(new AllPostsViewModel(posts));
        }
    }
}

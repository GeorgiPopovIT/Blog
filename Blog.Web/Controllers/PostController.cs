using Blog.Core.Contracts;
using Blog.Core.Models.Posts;
using Blog.Infrastructure.Data;
using Blog.Web.Common;
using Blog.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blog.Web.Controllers
{
    public class PostController : Controller
    {
        private UserManager<User> _userManager;
        private readonly ICommentService commentService;
        private readonly IPostService postService;
        private readonly IWebHostEnvironment environment;
        private readonly IUserService userService;

        public PostController(IPostService postService,
            IWebHostEnvironment environment,
            IUserService userService, ICommentService commentService,
            UserManager<User> userManager)
        {
            this.postService = postService;
            this.environment = environment;
            this.userService = userService;
            this.commentService = commentService;
            _userManager = userManager;
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
            var userId = await this.GetCurrentUserIdAsync();

            var posts =  await this.postService.GetAllPostsAsync(userId);

            return View(new AllPostsViewModel(posts));
        }

        private async Task<string> GetCurrentUserIdAsync() => (await _userManager.GetUserAsync(HttpContext.User)).Id;
    }
}

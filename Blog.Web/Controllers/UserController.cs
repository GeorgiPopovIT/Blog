using Blog.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;

        public UserController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IActionResult> GetUserImage(string? id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            var userImage = user.ImageProfile;

            return Ok();
        }
    }
}

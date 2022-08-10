using Blog.Core.Contracts;
using System.Security.Claims;

namespace Blog.Core.Services
{
    public class UserService : IUserService
    {
        public string GetUserId(ClaimsPrincipal user)
            => user.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}

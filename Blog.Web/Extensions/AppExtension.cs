using System.Security.Claims;

namespace Blog.Web.Extensions
{
    public static class AppExtension
    {
        public const string DirectoryPathSaveImage = $"/img/posts/";
        public static string GetUserId(this ClaimsPrincipal user) => user.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}

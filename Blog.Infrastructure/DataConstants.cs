
namespace Blog.Infrastructure
{
    internal static class DataConstants
    {
        // admin details must to store in secure place (user-secret) or other
        private const string AdministratorName = "Admin123";
        private const string AdministratorPassword = "1234567";
        private const string AdminRoleName = "Administrator";

        public const int MaxTitleLength = 500;
        public const int MaxCommentLength = short.MaxValue;
    }
}

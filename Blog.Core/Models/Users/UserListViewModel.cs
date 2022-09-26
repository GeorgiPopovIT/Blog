namespace Blog.Core.Models.Users
{
    //public record UserListViewModel(string Id, string FullName, string UserName);

    public class UserListViewModel
    {
        public string? Id { get; init; }

        public string? FullName { get; init; }

        public string? UserName { get; init; }

        public IList<string>? UserRoles { get; set; }
    }
}

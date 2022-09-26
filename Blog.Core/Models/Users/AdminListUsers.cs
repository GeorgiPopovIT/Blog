namespace Blog.Core.Models.Users
{
    //public record AdminListUsers(IEnumerable<string>? Roles, IEnumerable<UserViewModel>? Users);

    public class AdminListUsers
    {
        public IEnumerable<string>? Roles { get; set; }

        public IEnumerable<UserListViewModel>? Users { get; init; }

        public string? SearchByFullName { get; set; }
    }
}

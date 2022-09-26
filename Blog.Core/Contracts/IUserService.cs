using Blog.Core.Models.Users;
using System.Security.Claims;

namespace Blog.Core.Contracts
{
    public interface IUserService
    {
        string GetUserId(ClaimsPrincipal user);

        AdminListUsers GetAllUsers(string searchTerm);

        IEnumerable<UserListViewModel> GetUsersBySearchItem(string searchTerm);

        Task<string> MakeUserAdmin(string userId,string roleName); 
    }
}
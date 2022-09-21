using Blog.Core.Models.Users;
using System.Security.Claims;

namespace Blog.Core.Contracts
{
    public interface IUserService
    {
        string GetUserId(ClaimsPrincipal user);

        Task<AdminListUsers> GetAllUsers();
    }
}
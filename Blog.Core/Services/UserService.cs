using Blog.Core.Contracts;
using Blog.Core.Models.Users;
using Blog.Infrastructure;
using System.Security.Claims;

namespace Blog.Core.Services
{
    public class UserService : IUserService
    {
        private readonly BlogDbContext _dbContext;

        public UserService(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AdminListUsers> GetAllUsers()
        {
            var result = new AdminListUsers
            {
                Users = this._dbContext.Users.Select(u => new UserListViewModel
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    UserName = u.UserName
                })
            };

            return result;
        }

        public string GetUserId(ClaimsPrincipal user)
            => user.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}

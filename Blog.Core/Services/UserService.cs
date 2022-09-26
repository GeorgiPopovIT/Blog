using Blog.Core.Contracts;
using Blog.Core.Models.Users;
using Blog.Infrastructure;
using Blog.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Blog.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly BlogDbContext _dbContext;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserService(BlogDbContext dbContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            this.roleManager = roleManager;
        }

        public AdminListUsers GetAllUsers(string searchTerm)
        {
            var result = new AdminListUsers
            {
                Users = this.GetUsersBySearchItem(searchTerm)
            };

            return result;
        }

        public IEnumerable<UserListViewModel> GetUsersBySearchItem(string searchTerm)
        {
            var allUsers = this._dbContext.Users.Select(u => new UserListViewModel
            {
                Id = u.Id,
                FullName = u.FullName,
                UserName = u.UserName
            }).AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                allUsers = allUsers.Where(x => x.FullName.ToLower()
                .Contains(searchTerm.ToLower()));
            }

            return allUsers.ToList();
        }


        public string GetUserId(ClaimsPrincipal user)
            => user.FindFirstValue(ClaimTypes.NameIdentifier);

        public async Task<string> MakeUserAdmin(string userId, string roleName)
        {
            var user = await this._dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentNullException("User is invalid");
            }

            var rolesForUser = await this._userManager.GetRolesAsync(user);

            if (!rolesForUser.Contains(roleName))
            {
                await this._userManager.AddToRoleAsync(user, roleName);

                return "SuccessUserIsAdmin";
            }

            return "UserIsAlreadyAdmin";
        }
    }
}

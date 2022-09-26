using Blog.Core.Contracts;
using Blog.Infrastructure.Data;
using Blog.Web.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Areas.Identity.Admin.Controllers
{
    public class AdminController : BaseController
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userServie;

        public AdminController(RoleManager<IdentityRole> roleManager,
            IUserService userServie,
            UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userServie = userServie;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string searchByFullName)
        {

            var usersAndRoles = this._userServie.GetAllUsers(searchByFullName);

            usersAndRoles.Roles = await this._roleManager.Roles.Select(x => x.Name).ToListAsync();

            return View(usersAndRoles);
        }
        public async Task<IActionResult> MakeUserAdmin(string userId)
        {
            try
            {
               var result =  await this._userServie.MakeUserAdmin(userId, Constants.Roles.AdministratorRoleName);

                if (result == "SuccessUserIsAdmin")
                {
                    this.TempData[result] = "User is administrator";
                }
                else
                {
                    this.TempData[result] = "User is already administrator";
                }
            }
            catch (Exception ex)
            {

                this.TempData["InvalidUser"] = "User is invalid.";
            }

            return RedirectToAction(nameof(Index), nameof(Admin), null);
        }
    }
}

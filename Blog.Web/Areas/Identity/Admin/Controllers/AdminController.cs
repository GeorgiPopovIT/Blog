using Blog.Core.Contracts;
using Blog.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Identity.Admin.Controllers
{
    public class AdminController : BaseController
    {
        //private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userServie;

        public AdminController(/*RoleManager<IdentityRole> roleManager,*/IUserService userServie)
        {
           // _roleManager = roleManager;
            _userServie = userServie;
        }

        public async Task<IActionResult> Index()
        {
            var usersAndRoles = await this._userServie.GetAllUsers();

            //usersAndRoles.Roles = this._roleManager.Roles.Select(x => x.Name).ToList();

            return View(usersAndRoles);
        }
    }
}

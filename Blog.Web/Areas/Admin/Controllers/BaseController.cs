using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Blog.Web.Common;

namespace Blog.Web.Areas.Identity.Admin.Controllers
{
    [Authorize(Roles = Constants.Roles.AdministratorRoleName)]
    [Area("Admin")]
    public class BaseController : Controller
    {
    }
}

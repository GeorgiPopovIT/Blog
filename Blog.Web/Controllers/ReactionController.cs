using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class ReactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

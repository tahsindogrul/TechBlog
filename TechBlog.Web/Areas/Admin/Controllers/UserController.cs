using Microsoft.AspNetCore.Mvc;

namespace TechBlog.Web.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

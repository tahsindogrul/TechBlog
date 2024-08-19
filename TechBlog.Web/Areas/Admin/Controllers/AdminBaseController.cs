using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TechBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminBaseController : Controller
    {
        private readonly int _userId;
        public AdminBaseController()
        {
            //_userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _userId = 3;

        }
    }
}

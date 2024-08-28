using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechBlog.Business.Abstract;
using TechBlog.Models;

namespace TechBlog.Web.Areas.User.Controllers
{
    public class ProfileController : UserBaseController
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var user = _userService.GetUserById(id);
            return View(user);

        }

        [HttpPost]
        public IActionResult ProfileUpdate(AppUser user)
        {
            return Ok(_userService.ProfileUpdate(user));
        }

    }
}

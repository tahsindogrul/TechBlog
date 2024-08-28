using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechBlog.Web.Areas.Admin.Controllers;

namespace TechBlog.Web.Areas.User.Controllers
{

	public class HomeController : UserBaseController
	{
		public IActionResult Index()
		{
			string userid=User.FindFirstValue(ClaimTypes.NameIdentifier);
			return View();
		}
	}
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TechBlog.Web.Areas.User.Controllers
{
	[Area("User")]
	[Authorize(Roles = "User")]
	public class UserBaseController : Controller
	{



		public UserBaseController()
		{
		} 
    }
}

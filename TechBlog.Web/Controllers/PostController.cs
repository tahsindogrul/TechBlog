using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TechBlog.Business.Abstract;
using X.PagedList.Extensions;

namespace TechBlog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Kullanıcı giriş yapmış mı ve rolü admin mi kontrol et
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                // Admin ise admin alanına yönlendir
                if (!context.HttpContext.Request.Path.StartsWithSegments("/Admin"))
                {
                    context.Result =   Redirect("/Admin/Home/Index");
                    return;
                }
            }

            base.OnActionExecuting(context);
        }

        public IActionResult HomePage()
        {
            var recentPosts = _postService.GetRecentPosts(10); 
           
            return View(recentPosts);

        }

        public IActionResult PostDetails(int id)
        {
        

            return View(_postService.GetPostDetails(id));
        }

      
        
       
    }
}

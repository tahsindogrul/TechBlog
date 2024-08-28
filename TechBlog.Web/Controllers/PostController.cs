using Microsoft.AspNetCore.Mvc;
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

        public IActionResult HomePage()
        {
            var recentPosts = _postService.GetRecentPosts(10); 
           
            return View(recentPosts);

        }

        public IActionResult PostDetails(int id)
        {
            var post = _postService.GetById(id);            
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
        
       
    }
}

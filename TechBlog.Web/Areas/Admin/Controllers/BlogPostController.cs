using Microsoft.AspNetCore.Mvc;
using TechBlog.Business.Abstract;
using TechBlog.Models;

namespace TechBlog.Web.Areas.Admin.Controllers
{
    public class BlogPostController : AdminBaseController
    {
        private readonly IPostService _postService;

        public BlogPostController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
           
            return View(_postService.GetAllPosts());
        }

        [HttpGet]
        public IActionResult AdminPostEdit(int id)
        {
           
            return View(_postService.GetById(id));
        }

        [HttpPost]
        public IActionResult AdminPostEdit(Post post)
        {
            if(ModelState.IsValid)
            {
                _postService.Update(post);
                return RedirectToAction("Index");
            }
            return View(post);
        }
    }
}

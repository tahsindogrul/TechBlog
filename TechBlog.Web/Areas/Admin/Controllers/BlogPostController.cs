using Microsoft.AspNetCore.Mvc;
using TechBlog.Business.Abstract;
using TechBlog.Models;

namespace TechBlog.Web.Areas.Admin.Controllers
{
    public class BlogPostController : AdminBaseController
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        public BlogPostController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
           
            return View(_postService.GetAllPosts());
            
        }

        [HttpGet]
        public IActionResult AdminPostEdit(int id)
        {
            var posts = _postService.GetById(id);

            ViewBag.Categories = _categoryService.GetAll();
            
                

            return View(posts);
        }

        [HttpPost]
        public IActionResult AdminPostEdit(Post post)
        {

            if (ModelState.IsValid)
            {
                var existingPost = _postService.GetById(post.Id);

                if (existingPost != null)
                {
                    // Sadece Title, Content ve CategoryId'yi güncelle
                    existingPost.Title = post.Title;
                    existingPost.Content = post.Content;
                    existingPost.CategoryId = post.CategoryId;

                    // UserId'yi değiştirmiyoruz

                    _postService.Update(existingPost);
                    return Json(new { success = true });
                }
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return Json(new { success = false, message = "ModelState errors: " + string.Join(", ", errors) });

        }
    }
}

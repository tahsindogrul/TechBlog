using Microsoft.AspNetCore.Mvc;
using TechBlog.Business.Abstract;
using TechBlog.Models;
using TechBlog.Models.ViewModels;

namespace TechBlog.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;

        public CategoryController(ICategoryService categoryService, IPostService postService)
        {
            _categoryService = categoryService;
            _postService = postService;
        }

        public IActionResult GetCategory(int id)
        {
            var category= _categoryService.GetAll().FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            var posts = _postService.GetPostsByCategory(id);
            var model = new CategoryPostViewModel
            {
                Category = category,
                Posts = posts
            };
     
            return View(model);
        }
       
    }
}

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
        private readonly IUserService _userService;

        public CategoryController(ICategoryService categoryService, IPostService postService, IUserService userService)
        {
            _categoryService = categoryService;
            _postService = postService;
            _userService = userService;
        }

        public IActionResult GetCategory(int id)
        {
            var model = _categoryService.GetCategoryWithPosts(id);

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
       
    }
}

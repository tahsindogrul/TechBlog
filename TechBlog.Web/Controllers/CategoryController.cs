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
            var category= _categoryService.GetAll().FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            var posts = _postService.GetPostsByCategory(id);         
            var model = new CategoryPostViewModel
            {
                Category = category,
                Posts = posts.Select(p=>new Post
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    DateCreated = p.DateCreated,
                    User = p.User,
                   
                    
                }).ToList(),
            };
     
            return View(model);
        }
       
    }
}

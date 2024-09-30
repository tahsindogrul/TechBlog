using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechBlog.Business.Abstract;
using TechBlog.Business.Concrete;
using TechBlog.Models.ViewModels;

namespace TechBlog.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;
        private readonly IUserService _userService;


        public HomeController(ICategoryService categoryService, IPostService postService, IUserService userService)
        {
            _categoryService = categoryService;
            _postService = postService;
            _userService = userService;
        }

        public async Task< IActionResult> Index()
        {
            var model = new DashboardViewModel
            {
                TotalCategories = await _categoryService.GetTotalCategoriesCountAsync(),
                PendingPosts = await _postService.GetPendingPostsCountAsync(),
                TotalPosts = await _postService.GetTotalPostCountAsync(),
                TotalUsers = await _userService.GetUserCountAsync()
            };
            return View(model);
        }
    }
}

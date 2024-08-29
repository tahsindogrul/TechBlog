using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using TechBlog.Business.Abstract;
using TechBlog.Models;
using TechBlog.Models.ViewModels;

namespace TechBlog.Web.Areas.User.Controllers
{
    public class ProfileController : UserBaseController
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        public ProfileController(IUserService userService, IPostService postService, ICategoryService categoryService)
        {
            _userService = userService;
            _postService = postService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var user = _userService.GetUserById(id);
            return View(user);

        }

        [HttpPost]
        public IActionResult ProfileUpdate(AppUser user)
        {
            return Ok(_userService.ProfileUpdate(user));
        }


        [HttpGet]
        public IActionResult PostCreate()
        {
            var categories = _categoryService.GetAll().ToList();
            var model = new PostCreateViewModel
            {
                UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                Categories= new SelectList(categories,"Id","Name")

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddPost(PostCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var post = new Post
                {
                    Title = model.Title,
                    Content = model.Content,
                    UserId = model.UserId,
                    DateCreated = DateTime.Now,
                    CategoryId=model.SelectedCategoryId,
                };
                _postService.Add(post);
                return Json(new { success = true, message = "Post başarıyla eklendi!" });

            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, message = string.Join(", ", errors) });
        }





    }
}

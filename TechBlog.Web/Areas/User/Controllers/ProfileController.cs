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
				Categories = new SelectList(categories, "Id", "Name")

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
					IsPublished=false,
					DateCreated = DateTime.Now,
					CategoryId = model.SelectedCategoryId,
				};
				_postService.Add(post);
				return Json(new { success = true, message = "New post successfully added" });

			}
			var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
			return Json(new { success = false, message = string.Join(", ", errors) });
		}

		public IActionResult Posts()
		{
			var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
			var posts = _postService.GetPostsByUserId(userId);
			return View(posts);

		}

		[HttpGet]
		public IActionResult PostEdit(int id)
        {
            var post = _postService.GetById(id);
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (post == null || post.UserId.ToString() != userId) 
            {
                return NotFound();
            }

            var viewModel = new PostEditViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CategoryId = post.CategoryId,
                Categories = _categoryService.GetAll()
            };
            return View(viewModel);
        }

		[HttpPost] 
		public IActionResult PostEdit(PostEditViewModel viewModel)
		{
            if (ModelState.IsValid)
            {
                var post = _postService.GetById(viewModel.Id);
                if (post == null)
                {
                    return NotFound();
                }

                post.Title = viewModel.Title;
                post.Content = viewModel.Content;
                post.CategoryId = viewModel.CategoryId;
                post.DateUpdated = DateTime.Now;

                _postService.Update(post);
                return Redirect("/User/Profile/Posts");
            }

          
            viewModel.Categories = _categoryService.GetAll();
            return View(viewModel);
        }





	}
}

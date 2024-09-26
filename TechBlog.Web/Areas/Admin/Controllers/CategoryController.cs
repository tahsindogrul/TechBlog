using Microsoft.AspNetCore.Mvc;
using TechBlog.Business.Abstract;
using TechBlog.Models;

namespace TechBlog.Web.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public IActionResult Index()
        {

            return View(_categoryService.GetAll());
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Add(category);

                return Json(new
                {
                    success = true,
                    id = category.Id,
                    name = category.Name
                });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryService.GetById(id);

            if (category != null)
            {
                _categoryService.Delete(id);
                return Json(new { success = true, id = category.Id });
            }
            return Json(new { success = false, message = "Category not found." });

        }
    }
}

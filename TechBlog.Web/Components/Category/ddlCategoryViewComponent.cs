using Microsoft.AspNetCore.Mvc;
using TechBlog.Business.Abstract;

namespace TechBlog.Web.Components.Category
{
    public class ddlCategoryViewComponent:ViewComponent
    {
        private readonly ICategoryService _categoryService;
  

        public ddlCategoryViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryService.GetAll();
            return View("CategoryDDL",categories);
        }
    }
}

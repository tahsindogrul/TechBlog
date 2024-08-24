using Microsoft.AspNetCore.Mvc;
using TechBlog.Business.Abstract;

namespace TechBlog.Web.Components.Category
{
    public class CategoryViewComponent:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categorires = _categoryService.GetAll();
            return View(categorires);
        }
    }
}

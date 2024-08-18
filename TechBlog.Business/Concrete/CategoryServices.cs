using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Business.Abstract;
using TechBlog.Business.Shared.Concrete;
using TechBlog.Models;
using TechBlog.Repository.Shared.Abstract;

namespace TechBlog.Business.Concrete
{
    public class CategoryServices : Services<Category>, ICategoryServices
    {
        private readonly IRepository<Category> _categoryRepo;

        public CategoryServices(IRepository<Category> categoryRepo):base(categoryRepo) 
        {
            _categoryRepo = categoryRepo;
        }
    }
}

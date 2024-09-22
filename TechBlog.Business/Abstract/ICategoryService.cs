using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Business.Shared.Abstract;
using TechBlog.Models;
using TechBlog.Models.ViewModels;

namespace TechBlog.Business.Abstract
{
    public interface ICategoryService: IService<Category>
    {
        CategoryPostViewModel GetCategoryWithPosts(int id );
    }
}

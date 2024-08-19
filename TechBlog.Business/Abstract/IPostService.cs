using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Business.Shared.Abstract;
using TechBlog.Models;

namespace TechBlog.Business.Abstract
{
    public interface IPostService:IService<Post>
    {
    }
}

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
    public class PostService:Service<Post>,IPostService
    {
        private readonly IRepository<Post> _postRepo;

        public PostService(IRepository<Post> postRepo):base(postRepo) 
        {
            _postRepo = postRepo;
        }
    }
}

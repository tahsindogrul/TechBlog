using Microsoft.EntityFrameworkCore;
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
    public class CommentService:Service<Comment>,ICommentService
    {
        private readonly IRepository<Comment> _commentRepo;

        public CommentService(IRepository<Comment> commentRepo):base(commentRepo)
        {
            _commentRepo = commentRepo;
        }

       
    }
}

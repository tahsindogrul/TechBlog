﻿using System;
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
    public class CommentServices:Services<Comment>,ICommentServices
    {
        private readonly IRepository<Comment> _commentRepo;

        public CommentServices(IRepository<Comment> commentRepo):base(commentRepo)
        {
            _commentRepo = commentRepo;
        }
    }
}

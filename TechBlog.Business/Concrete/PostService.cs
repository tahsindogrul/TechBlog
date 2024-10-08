﻿using System.Security.Claims;
using Microsoft.AspNetCore.Http;
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
    public class PostService : Service<Post>, IPostService
    {
        private readonly IRepository<Post> _postRepo;
        private readonly IUserService _userService;



        public PostService(IRepository<Post> postRepo, IUserService userService) : base(postRepo)
        {
            _postRepo = postRepo;
            _userService = userService;

        }

        public IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            var posts = base.GetAll(p => p.CategoryId == categoryId && p.IsPublished && !p.IsDeleted).ToList();
            foreach (var post in posts)
            {
                post.User = _userService.GetById(post.UserId);


            }
            return posts;
        }


        public IEnumerable<Post> GetRecentPosts(int count)
        {
            var recentpost = _postRepo.GetAll().Where(p => p.IsPublished).OrderByDescending(p => p.DateCreated).Take(count).ToList();
            foreach (var recent in recentpost)
            {

                recent.User = _userService.GetById(recent.UserId);
            }
            return recentpost;
        }

        public override Post GetById(int id)
        {
            return _postRepo.GetAll()
                .Include(p => p.Comments)
                .ThenInclude(c => c.User)
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Post> GetPostsByUserId(int userId)
        {
            return _postRepo.GetAll().Where(p => p.UserId == userId).ToList();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _postRepo.GetAll().Where(p => p.IsPublished).Include(p => p.User).ToList();
        }

        public IEnumerable<Post> GetPendingPosts()
        {
            return _postRepo.GetAll().Where(p => p.IsPublished == false && !p.IsDeleted).Include(p => p.User).ToList();
        }

        public Task<int> GetTotalPostCountAsync()
        {
            return _postRepo.GetAll().Where(p => p.IsPublished).CountAsync();
        }

        public Task<int> GetPendingPostsCountAsync()
        {
            return _postRepo.GetAll().Where(p => p.IsPublished == false).CountAsync();
        }

        public IEnumerable<Post> GetPopularPosts()
        {
            return _postRepo.GetAll().OrderByDescending(p => p.Comments.Count()).Take(5).ToList();
        }

        public Post GetPostDetails(int id)
        {
            var post = _postRepo.GetAll()
          .Include(p => p.User)
          .Include(p => p.Comments)
          .ThenInclude(c => c.User)
          .FirstOrDefault(p => p.Id == id);

            return post;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Business.Abstract;
using TechBlog.Business.Shared.Concrete;
using TechBlog.Models;
using TechBlog.Models.ViewModels;
using TechBlog.Repository.Shared.Abstract;

namespace TechBlog.Business.Concrete
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IPostService _postService;

        public CategoryService(IRepository<Category> categoryRepo, IPostService postService) : base(categoryRepo)
        {
            _categoryRepo = categoryRepo;
            _postService = postService;
        }


        public CategoryPostViewModel GetCategoryWithPosts(int id)
        {
            var category = _categoryRepo.GetAll().FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return null;
            }

            var posts = _postService.GetPostsByCategory(id);
            var model = new CategoryPostViewModel
            {
                Category = category,
                Posts = posts.Select(p => new Post
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    DateCreated = p.DateCreated,
                    User = p.User,
                    PhotoUrl = p.PhotoUrl,

                }).ToList(),
            };

            return model;

        }

        public async Task<int> GetTotalCategoriesCountAsync()
        {
            return await  _categoryRepo.GetAll().CountAsync();
        }
    }
}


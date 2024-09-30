using Microsoft.AspNetCore.Mvc;
using TechBlog.Business.Abstract;

namespace TechBlog.Web.Components.Posts
{
    public class PopularPostsViewComponent :ViewComponent
    {
        private readonly IPostService _postService;

        public PopularPostsViewComponent(IPostService postService)
        {
            _postService = postService;
        }

        public IViewComponentResult Invoke()
        {
            var popularPosts=  _postService.GetPopularPosts();
            return View(popularPosts);
        }
    }
}

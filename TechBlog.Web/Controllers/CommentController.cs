using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechBlog.Business.Abstract;
using TechBlog.Models;

namespace TechBlog.Web.Controllers
{
	public class CommentController : Controller
	{
		private readonly  ICommentService _commentService;
		


		public CommentController(ICommentService commentService)
		{

			_commentService = commentService;
			
		}
	

		[HttpPost]
		public IActionResult SubmitComment(Comment comment)
		{
			

			if (ModelState.IsValid)
			{
				

				var userId=int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
				comment.UserId = userId;
				comment.DateCreated = DateTime.Now;
				_commentService.Add(comment);
				return RedirectToAction("PostDetails", "Post", new {id = comment.PostId});
			}
			
			return RedirectToAction("PostDetails", "Post", new { id = comment.PostId });

		}
	}
}

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;
using TechBlog.Business.Abstract;
using TechBlog.Business.Concrete;
using TechBlog.Dtos.UserDTOs;
using TechBlog.Models;
using TechBlog.Models.ViewModels;

namespace TechBlog.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            LoginDTO dto = await _userService.Login(loginDTO);

            if(dto.Role !=null)
            {
                if (dto.Role == "Admin")
                {
                    return Redirect("/Admin/Home/Index");


                }
                else
                {
                    return RedirectToAction("HomePage", "Post");
                }
            }
          
         
            return RedirectToAction("Login");

        }


        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            return Json(new { success = true });
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterAsync(model);
                if (result)
                {

                    TempData["SuccessMessage"] = "Registration successful! You can now log in.";
                    return RedirectToAction("Register");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
                }
            }
            return View(model);
        }
    }
}


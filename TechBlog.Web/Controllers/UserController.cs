using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechBlog.Business.Abstract;
using TechBlog.Business.Concrete;
using TechBlog.Dtos.UserDTOs;
using TechBlog.Models;

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
        public IActionResult Login(LoginDTO loginDTO)
        {
            AppUser appUser = new AppUser();
            appUser.Email = loginDTO.Email;
            appUser.Password = loginDTO.Password;

            AppUser loginAppUser = _userService.CheckUser(appUser);

            if (loginAppUser != null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Email, loginAppUser.Email));
                claims.Add(new Claim(ClaimTypes.Name, loginAppUser.UserName));
                claims.Add(new Claim(ClaimTypes.NameIdentifier,loginAppUser.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Role, loginAppUser.IsAdmin ? "Admin" : "User"));

                ClaimsIdentity identity = new ClaimsIdentity(claims, "Login");

                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties
                {
                    IsPersistent = loginDTO.IsRememberMe
                });

                if (loginAppUser.IsAdmin)
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { area = "User" });

                }
            }
            else
            {
                return View();
            }
        }
    }
}

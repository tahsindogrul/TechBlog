﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Business.Abstract;
using TechBlog.Business.Shared.Concrete;
using TechBlog.Dtos.UserDTOs;
using TechBlog.Models;
using TechBlog.Models.ViewModels;
using TechBlog.Repository.Shared.Abstract;

namespace TechBlog.Business.Concrete
{
    public class UserService : Service<AppUser>, IUserService
    {
        private readonly IRepository<AppUser> _userRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public UserService(IRepository<AppUser> userRepo, IHttpContextAccessor httpContextAccessor) : base(userRepo)
        {
            _userRepo = userRepo;
            _httpContextAccessor = httpContextAccessor;
        }

        public AppUser CheckUser(AppUser appUser)
        {
            return _userRepo.GetFirstOrDefault(x => x.Email == appUser.Email && x.Password == appUser.Password);
        }

        public AppUser GetUserById(int userId)
        {
            return _userRepo.GetById(userId);
        }

        public Task<int> GetUserCountAsync()
        {
            return _userRepo.GetAll().Where(u => u.IsAdmin == false).CountAsync();
        }

        public async Task<LoginDTO> Login(LoginDTO loginDTO)
        {
            AppUser user = _userRepo.GetFirstOrDefault(x => x.Email == loginDTO.Email && x.Password == loginDTO.Password);


            if (user != null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Email, user.Email));
                claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User"));

                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties
                {
                    IsPersistent = loginDTO.IsRememberMe
                });
                loginDTO.Role = user.IsAdmin ? "Admin" : "User";
                return loginDTO;
            }
            return loginDTO;
        }


        public async Task Logout()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);


        }

        public AppUser ProfileUpdate(AppUser user)
        {
            var currentUser = GetFirstOrDefault(u => u.Id == user.Id);

            currentUser.UserName = user.UserName;
            currentUser.Email = user.Email;
            currentUser.Password = user.Password;
            currentUser.About = user.About;
            return Update(currentUser);
        }


        public async Task<bool> RegisterAsync(RegisterViewModel model)
        {
            var existingUser = _userRepo.GetFirstOrDefault(u => u.Email == model.Email);

            if (existingUser != null)
            {
                return false;
            }

            if (model.Password != model.ConfirmPassword)
            {
                return false; 
            }

            var newUser = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password,
                DateCreated = DateTime.Now
            };

            _userRepo.Add(newUser);
            return true;


        }
    }
}

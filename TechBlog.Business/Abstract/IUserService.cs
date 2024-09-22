using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Business.Shared.Abstract;
using TechBlog.Dtos.UserDTOs;
using TechBlog.Models;

namespace TechBlog.Business.Abstract
{
    public interface IUserService:IService<AppUser>
    {
        Task<LoginDTO> Login(LoginDTO loginDTO);

        AppUser CheckUser(AppUser appUser);
        AppUser GetUserById(int userId);
        Task Logout();
        AppUser ProfileUpdate(AppUser appUser);
    }
}

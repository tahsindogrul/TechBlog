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
    public class UserServices:Services<AppUser>,IUserServices
    {
        private readonly IRepository<AppUser> _userRepo;

        public UserServices(IRepository<AppUser> userRepo) : base(userRepo)
        {
            _userRepo = userRepo;
        }

        public AppUser CheckUser(AppUser appUser)
        {
            return _userRepo.GetAll().Where(x=>x.Email==appUser.Email && 
            x.Password==appUser.Password).FirstOrDefault();
        }
    }
}

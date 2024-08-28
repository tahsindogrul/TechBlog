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
    public class UserService:Service<AppUser>,IUserService
    {
        private readonly IRepository<AppUser> _userRepo;

        public UserService(IRepository<AppUser> userRepo) : base(userRepo)
        {
            _userRepo = userRepo;
        }

        public AppUser CheckUser(AppUser appUser)
        {
            return _userRepo.GetAll().Where(x=>x.Email==appUser.Email && 
            x.Password==appUser.Password).FirstOrDefault();
        }

        public AppUser GetUserById(int userId)
        {
            return _userRepo.GetById(userId);
        }

        public AppUser ProfileUpdate(AppUser user)
        {
           var currentUser =GetFirstOrDefault(u=>u.Id==user.Id);

            currentUser.UserName = user.UserName;
            currentUser.Email = user.Email;
            currentUser.Password = user.Password;
            return Update(currentUser);
        }
    }
}

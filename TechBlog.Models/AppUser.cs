using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlog.Models
{
    public class AppUser: BaseModel
    {
       
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? ProfilePicture { get; set; }
        public bool IsAdmin { get; set; }=false;
        public DateTime DateCreated { get; set; }= DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
        public virtual ICollection<Post> Posts { get; set; }= new List<Post>();

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}

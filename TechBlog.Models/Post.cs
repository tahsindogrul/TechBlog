using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlog.Models
{
    public class Post: BaseModel
    {
      
        public string Title { get; set; }
        public string Content { get; set; }
        public  DateTime DateCreated { get; set; }= DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
      
        public bool IsPublished { get; set; }
        public int UserId { get; set; }
        public virtual AppUser User { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}

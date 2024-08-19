using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlog.Models
{
    public class Category: BaseModel
    {
     
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}

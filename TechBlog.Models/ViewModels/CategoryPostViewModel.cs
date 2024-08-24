using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlog.Models.ViewModels
{
    public class CategoryPostViewModel
    {
        public Category Category { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}

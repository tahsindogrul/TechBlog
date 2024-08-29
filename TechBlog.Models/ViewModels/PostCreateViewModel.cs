using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlog.Models.ViewModels
{
    public class PostCreateViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public IEnumerable<SelectListItem>? Categories { get; set; }
        public int SelectedCategoryId { get; set; }
    }
}

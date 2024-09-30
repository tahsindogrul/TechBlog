using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlog.Models.ViewModels
{
    public class DashboardViewModel
    {
         public int TotalCategories { get; set; }
        public int PendingPosts {  get; set; }
        public int TotalUsers { get; set; }
        public int TotalPosts { get; set; }

    }
}

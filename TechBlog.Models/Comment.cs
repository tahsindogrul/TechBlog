﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlog.Models
{
    public class Comment: BaseModel
    {
    
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }= DateTime.Now;
        public int PostId { get; set; }
        public virtual Post? Post { get; set; }
        public int UserId { get; set; }
        public virtual AppUser? User { get; set; }

    }
}

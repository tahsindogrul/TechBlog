﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public  DateTime DateCreated { get; set; }= DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}

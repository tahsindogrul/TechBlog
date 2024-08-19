using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Models;

namespace TechBlog.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name = "Programming" },
                new Category { Id = 2, Name = "Web Development" },
                new Category { Id = 3, Name = "Mobile Development" },
                new Category { Id = 4, Name = "Data Science" },
                new Category { Id = 5, Name = "Artificial Intelligence" },
                new Category { Id = 6, Name = "DevOps" },
                new Category { Id = 7, Name = "Cloud Computing" },
                new Category { Id = 8, Name = "Cybersecurity" },
                new Category { Id = 9, Name = "Tech News" }
               
            );
        }
    }
}

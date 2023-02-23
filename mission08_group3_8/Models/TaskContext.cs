using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission08_group3_8.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext (DbContextOptions<TaskContext> options) : base (options)
        {

        }

        public DbSet<ApplicationResponse> responses { get; set; }
        public DbSet<Category> categories { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Home"},
                new Category { CategoryID = 2, CategoryName = "School" },
                new Category { CategoryID = 3, CategoryName = "Work" },
                new Category { CategoryID = 4, CategoryName = "Church" }


                );
            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    TaskID = 1,
                    Task = "Finish Midterm",
                    CategoryID = 2,
                    Completed = false,
                    DueDate = "Wednesday",
                    Quadrant = 1,

                    
                }
                );
        }
    }
}

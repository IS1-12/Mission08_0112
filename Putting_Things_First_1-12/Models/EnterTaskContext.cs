using Microsoft.EntityFrameworkCore;

namespace Putting_Things_First_1_12.Models
{
    public class EnterTaskContext : DbContext
    {
        public EnterTaskContext(DbContextOptions<EnterTaskContext> options) : base (options) 
        {
        }

        public DbSet<TaskEntry> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
                );
        }
    }
}

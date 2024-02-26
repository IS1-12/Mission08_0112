using Microsoft.EntityFrameworkCore;

namespace Putting_Things_First_1_12.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base (options) 
        {
        }

        public DbSet<Task> Tasks { get; set; }
    }
}

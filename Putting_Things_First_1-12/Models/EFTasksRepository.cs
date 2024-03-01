
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Putting_Things_First_1_12.Models
{
    public class EFTasksRepository : ITasksRepository
    {
        private EnterTaskContext _context;
        public EFTasksRepository(EnterTaskContext temp) 
        {
            _context = temp;
        }
        public List<TaskEntry> Tasks => _context.Tasks
            .Where(x => x.Completed==false)
            .Include(b => b.Category)
            .ToList();

        public List<Category> Categories => _context.Categories.ToList();

        public void Add(TaskEntry entry)
        {
            _context.Add(entry);
            _context.SaveChanges();
        }

        public TaskEntry Update(int id) => _context.Tasks
            .Single(x => x.TaskId == id);

        public void Update(TaskEntry t)
        {
            _context.Update(t); 
            _context.SaveChanges();
        }

        public TaskEntry Delete(int id) => _context.Tasks
            .Single(x => x.TaskId == id);

        public void Delete(TaskEntry t)
        {
            _context.Tasks.Remove(t);
            _context.SaveChanges();
        }
    }
}

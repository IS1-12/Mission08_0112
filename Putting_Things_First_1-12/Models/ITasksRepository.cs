namespace Putting_Things_First_1_12.Models
{
    public interface ITasksRepository
    {
        List<TaskEntry> Tasks { get; }

        List<Category> Categories { get; }

        public void Add(TaskEntry entry);

        public TaskEntry Update(int id);

        public void Update(TaskEntry t);

        public TaskEntry Delete(int id);

        public void Delete(TaskEntry t);
    }
}

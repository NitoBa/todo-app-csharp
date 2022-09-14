using TaskRepositories;
using Entities;

namespace InMemoryRepositories
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<TaskEntity> Tasks = new List<TaskEntity>();
        public TaskEntity create(string Title)
        {
            string uuid = Guid.NewGuid().ToString();
            var task = new TaskEntity(uuid, Title, false);
            this.Tasks.Add(task);

            return task;
        }

        public List<TaskEntity> getAllTasks()
        {
            return this.Tasks;
        }

        public TaskEntity? GetTaskById(string TaskId)
        {
            var task = this.Tasks.Find(task => task.Id == TaskId);

            return task;
        }

        public TaskEntity? ToggleTask(string id)
        {
            var taskIndex = this.Tasks.FindIndex(task => task.Id == id);
            if (taskIndex == -1) return null;

            var task = this.Tasks.First(task => task.Id == id);

            task.isCompleted = !task.isCompleted;

            this.Tasks[taskIndex] = task;

            return task;
        }

        public TaskEntity? UpdateTitleTask(string id, string title)
        {
            var taskIndex = this.Tasks.FindIndex(task => task.Id == id);
            if (taskIndex == -1) return null;

            var task = this.Tasks.First(task => task.Id == id);

            task.Title = title;

            this.Tasks[taskIndex] = task;

            return task;
        }

        public bool Delete(string id)
        {
            var taskIndex = this.Tasks.FindIndex(task => task.Id == id);
            if (taskIndex == -1) return false;

            this.Tasks.RemoveAt(taskIndex);
            return true;
        }
    }
}
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

            this.Tasks[taskIndex].isCompleted = !this.Tasks[taskIndex].isCompleted;

            return this.Tasks[taskIndex];
        }

        public TaskEntity? UpdateTitleTask(string id, string title)
        {
            var taskIndex = this.Tasks.FindIndex(task => task.Id == id);
            if (taskIndex == -1) return null;

            this.Tasks[taskIndex].Title = title;

            return this.Tasks[taskIndex];
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
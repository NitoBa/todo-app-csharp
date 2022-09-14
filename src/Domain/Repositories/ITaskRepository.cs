using Entities;

namespace TaskRepositories
{
    public interface ITaskRepository
    {
        TaskEntity create(string Title);
        List<TaskEntity> getAllTasks();

        TaskEntity? GetTaskById(string TaskId);
        TaskEntity? ToggleTask(string id);
        TaskEntity? UpdateTitleTask(string id, string title);
        bool Delete(string id);
    }
}
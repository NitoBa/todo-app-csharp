using Entities;
using Microsoft.AspNetCore.Mvc;
using TaskRepositories;

namespace TodoApp.Src.Domain.Usecases
{
    public class ListAllTasksUsecase
    {
        ITaskRepository repository;
        public ListAllTasksUsecase([FromServices] ITaskRepository repository)
        {
            this.repository = repository;
        }

        public List<TaskEntity> Execute()
        {
            return this.repository.getAllTasks();
        }
    }
}
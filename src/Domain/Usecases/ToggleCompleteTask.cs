using Entities;
using Errors.AppErrors;
using Microsoft.AspNetCore.Mvc;
using TaskRepositories;

namespace TodoApp.Src.Domain.Usecases
{
    public class ToggleCompleteTaskUsecase
    {
        ITaskRepository repository;
        public ToggleCompleteTaskUsecase([FromServices] ITaskRepository repository)
        {
            this.repository = repository;
        }

        public TaskEntity? Execute(string id)
        {

            var taskExists = this.repository.GetTaskById(id);

            if (taskExists == null)
            {
                throw new NotFoundException($"Task with id: {id} not found");
            }

            var task = this.repository.ToggleTask(id);

            return task;
        }
    }
}
using Entities;
using Errors.AppErrors;
using Microsoft.AspNetCore.Mvc;
using TaskRepositories;

namespace TodoApp.Src.Domain.Usecases
{
    public class UpdateTitleTaskUsecase
    {
        ITaskRepository repository;
        public UpdateTitleTaskUsecase([FromServices] ITaskRepository repository)
        {
            this.repository = repository;
        }

        public TaskEntity? Execute(string id, string title)
        {
            if (title == null || title == string.Empty) throw new RequiredArgumentException("Title is required");
            if (id == null || id == string.Empty) throw new RequiredArgumentException("Id is required");

            var taskExists = this.repository.GetTaskById(id);

            if (taskExists == null)
            {
                throw new NotFoundException($"Task with id: {id} not found");
            }

            var task = this.repository.UpdateTitleTask(id, title);

            return task;
        }
    }
}
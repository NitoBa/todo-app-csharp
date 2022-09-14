using Entities;
using Errors.AppErrors;
using Microsoft.AspNetCore.Mvc;
using TaskRepositories;

namespace TodoApp.Src.Domain.Usecases
{
    public class CreateNewTaskUsecase
    {
        ITaskRepository repository;
        public CreateNewTaskUsecase([FromServices] ITaskRepository repository)
        {
            this.repository = repository;
        }
        public TaskEntity Execute(string title)
        {
            if (title == null || title == string.Empty) throw new RequiredArgumentException("Title is required");
            return this.repository.create(title);
        }
    }
}
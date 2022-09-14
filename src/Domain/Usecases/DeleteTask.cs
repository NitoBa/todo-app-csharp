

using Errors.AppErrors;
using Microsoft.AspNetCore.Mvc;
using TaskRepositories;

namespace TodoApp.Src.Domain.Usecases
{
    public class DeleteTaskUsecase
    {
        ITaskRepository repository;
        public DeleteTaskUsecase([FromServices] ITaskRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(string id)
        {
            if (id == null || id == string.Empty) throw new RequiredArgumentException("Id is required");

            if (!this.repository.Delete(id))
            {
                throw new NotFoundException($"Task with id: {id} not found");
            }
        }
    }


}
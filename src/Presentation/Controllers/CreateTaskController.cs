using DTOs;
using Errors.AppErrors;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Src.Domain.Usecases;
namespace Presentation.Controllers
{
    public class CreateTaskController
    {
        private readonly CreateNewTaskUsecase Usecase;
        public CreateTaskController([FromServices] CreateNewTaskUsecase usecase) => this.Usecase = usecase;


        public IResult Handle(CreateTaskDTO body)
        {
            try
            {
                var task = this.Usecase.Execute(body.Title);

                return Results.Created("/tasks", task);
            }
            catch (RequiredArgumentException error)
            {
                return Results.BadRequest(new { error = error.Message });
            }
            catch (System.Exception)
            {

                return Results.Problem();
            }
        }
    }
}
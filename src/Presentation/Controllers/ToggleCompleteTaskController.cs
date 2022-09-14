using DTOs;
using Errors.AppErrors;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Src.Domain.Usecases;

namespace Presentation.Controllers
{
    public class ToggleCompleteTaskController
    {
        private readonly ToggleCompleteTaskUsecase Usecase;
        public ToggleCompleteTaskController([FromServices] ToggleCompleteTaskUsecase usecase) => Usecase = usecase;


        public IResult Handle(string id)
        {
            try
            {
                var tasks = this.Usecase.Execute(id);

                return Results.Ok(tasks);
            }
            catch (NotFoundException error)
            {
                return Results.NotFound(new { message = error.Message });
            }
            catch (System.Exception)
            {

                return Results.Problem();
            }
        }
    }
}
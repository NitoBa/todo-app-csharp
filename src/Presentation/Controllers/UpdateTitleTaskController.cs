using DTOs;
using Errors.AppErrors;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Src.Domain.Usecases;
namespace Presentation.Controllers
{
    public class UpdateTitleTaskController
    {
        private readonly UpdateTitleTaskUsecase Usecase;
        public UpdateTitleTaskController([FromServices] UpdateTitleTaskUsecase usecase) => Usecase = usecase;


        public IResult Handle(UpdateTitleTaskDTO body)
        {
            try
            {
                var task = this.Usecase.Execute(body.Id, body.Title);

                return Results.Ok(task);
            }
            catch (RequiredArgumentException error)
            {
                return Results.BadRequest(new { error = error.Message });
            }
            catch (NotFoundException error)
            {
                return Results.NotFound(new { error = error.Message });
            }
            catch (System.Exception)
            {

                return Results.Problem();
            }
        }
    }
}
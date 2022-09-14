using DTOs;
using Errors.AppErrors;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Src.Domain.Usecases;

namespace Presentation.Controllers
{
    public class DeleteTaskController
    {
        private readonly DeleteTaskUsecase Usecase;
        public DeleteTaskController([FromServices] DeleteTaskUsecase usecase) => Usecase = usecase;


        public IResult Handle(string id)
        {
            try
            {
                this.Usecase.Execute(id);

                return Results.NoContent();
            }
            catch (NotFoundException error)
            {
                return Results.NotFound(new { message = error.Message });
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
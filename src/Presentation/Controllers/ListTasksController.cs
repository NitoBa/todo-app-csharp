using Microsoft.AspNetCore.Mvc;
using TodoApp.Src.Domain.Usecases;

namespace Presentation.Controllers
{
    public class ListTaskController
    {
        private readonly ListAllTasksUsecase Usecase;
        public ListTaskController([FromServices] ListAllTasksUsecase usecase) => Usecase = usecase;


        public IResult Handle()
        {
            try
            {
                var tasks = this.Usecase.Execute();

                return Results.Ok(tasks);
            }
            catch (System.Exception)
            {

                return Results.Problem();
            }
        }
    }
}
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers;

namespace HttpRest
{
    public class Routes
    {
        private readonly WebApplication App;
        public Routes(WebApplication app)
        {
            this.App = app;
        }

        public void MountRoutes()
        {
            this.App.MapGet("/tasks", ([FromServices] ListTaskController controller) => controller.Handle());

            this.App.MapPost("/tasks", ([FromServices] CreateTaskController controller, [FromBody] CreateTaskDTO body) => controller.Handle(body));
            this.App.MapPut("/tasks/{id}", ([FromServices] ToggleCompleteTaskController controller, string id) => controller.Handle(id));
            this.App.MapPut("/tasks", ([FromServices] UpdateTitleTaskController controller, [FromBody] UpdateTitleTaskDTO body) => controller.Handle(body));
            this.App.MapDelete("/tasks/{id}", ([FromServices] DeleteTaskController controller, string id) => controller.Handle(id));
        }
    }
}
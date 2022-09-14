
using DTOs;
using InMemoryRepositories;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers;
using TaskRepositories;
using TodoApp.Src.Domain.Usecases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();
builder.Services.AddSingleton<CreateNewTaskUsecase>();
builder.Services.AddSingleton<ListAllTasksUsecase>();
builder.Services.AddSingleton<ToggleCompleteTaskUsecase>();
builder.Services.AddSingleton<UpdateTitleTaskUsecase>();
builder.Services.AddSingleton<DeleteTaskUsecase>();
builder.Services.AddSingleton<ListTaskController>();
builder.Services.AddSingleton<CreateTaskController>();
builder.Services.AddSingleton<ToggleCompleteTaskController>();
builder.Services.AddSingleton<UpdateTitleTaskController>();
builder.Services.AddSingleton<DeleteTaskController>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/tasks", ([FromServices] ListTaskController controller) => controller.Handle());

app.MapPost("/tasks", ([FromServices] CreateTaskController controller, [FromBody] CreateTaskDTO body) => controller.Handle(body));
app.MapPut("/tasks/{id}", ([FromServices] ToggleCompleteTaskController controller, string id) => controller.Handle(id));
app.MapPut("/tasks", ([FromServices] UpdateTitleTaskController controller, [FromBody] UpdateTitleTaskDTO body) => controller.Handle(body));
app.MapDelete("/tasks/{id}", ([FromServices] DeleteTaskController controller, string id) => controller.Handle(id));


app.Run();
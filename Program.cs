using HttpRest;
using InMemoryRepositories;
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
new Routes(app).MountRoutes();
app.Run();
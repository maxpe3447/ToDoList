using Microsoft.EntityFrameworkCore;
using ToDoListApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Run();

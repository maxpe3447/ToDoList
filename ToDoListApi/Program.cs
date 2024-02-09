using Microsoft.EntityFrameworkCore;
using ToDoListApi.Data;
using ToDoListApi.Services.JwtTokenService;
using ToDoListApi.Services.LoginService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ToDoListApi.Services.RegistrationService;
using ToDoListApi.Services.TaskService;
using ToDoListApi.Controllers;
var builder = WebApplication.CreateBuilder(new WebApplicationOptions { WebRootPath = "wwwroot/browser" });

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IRegistrationService, RegistrationService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
builder.Services.AddAuthorization();
var app = builder.Build();

app.UseCors(builder => builder.AllowAnyHeader()
                              .AllowAnyMethod()
                              .WithOrigins("http://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.UseDefaultFiles();

app.MapControllers();
app.MapFallbackToController(nameof(FallBackController.Index), nameof(FallBackController).Replace("Controller",""));

var scoped = app.Services.CreateScope();
scoped.ServiceProvider.GetService<AppDbContext>().Database.Migrate();

app.Run();

using Microsoft.EntityFrameworkCore;
using ToDoListApi.Data;
using ToDoListApi.Services.JwtTokenService;
using ToDoListApi.Services.LoginService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ToDoListApi.Services.RegistrationService;
using ToDoListApi.Services.TaskService;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
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

app.MapControllers();

app.Run();

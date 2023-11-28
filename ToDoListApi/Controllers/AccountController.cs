using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using ToDoListApi.Data.Entities;
using ToDoListApi.Models;
using ToDoListApi.Services.LoginService;
using ToDoListApi.Services.RegistrationService;

namespace ToDoListApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IRegistrationService _registrationService;
    private readonly ILoginService _loginService;

    public AccountController(IRegistrationService registrationService, 
                             ILoginService loginService)
    {
        _registrationService = registrationService;
        _loginService = loginService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserModel>> Register(RegisterModel user)
    {
        if(await _registrationService.IsExists(user))
        {
            return BadRequest("Username is taken");
        }

        return await _registrationService.Registration(user);
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserModel>>Login(LoginModel login)
    {
        var user = await _loginService.IsExists(login);
        if(user == null)
        {
            return Unauthorized("Invalid User");
        }

        var result = _loginService.Login(user, login);
        if(result == default)
        {
            return Unauthorized("Invalid password");
        }
        return result;
    }
}

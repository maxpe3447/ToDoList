using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using ToDoListApi.Data.Entities;
using ToDoListApi.Models;
using ToDoListApi.Services.RegistrationService;

namespace ToDoListApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IRegistrationService _registrationService;

    public AccountController(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
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
}

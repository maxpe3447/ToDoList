using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using ToDoListApi.Data;
using ToDoListApi.Data.Entities;
using ToDoListApi.Models;
using ToDoListApi.Services.JwtTokenService;

namespace ToDoListApi.Services.RegistrationService
{
    public class RegistrationService : IRegistrationService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IJwtTokenService _jwtTokenService;

        public RegistrationService(AppDbContext appDbContext, 
                                   IJwtTokenService jwtTokenService)
        {
            _appDbContext = appDbContext;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<bool> IsExists(RegisterModel user)
        {
            return await _appDbContext.Users.AnyAsync(x=>x.Username == user.Username);
        }

        public async Task<UserModel> Registration(RegisterModel register)
        {
            using var hmac = new HMACSHA512();

            var user = new User
            {
                Username = register.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(register.Password)),
                PasswordSalt = hmac.Key
            };

            _appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();

            return new UserModel
            {
                Username = user.Username,
                Token = _jwtTokenService.CreateToken(user)
            };
        }
    }
}

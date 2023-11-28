using ToDoListApi.Data.Entities;

namespace ToDoListApi.Services.JwtTokenService
{
    public interface IJwtTokenService
    {
        string CreateToken(User user);
    }
}

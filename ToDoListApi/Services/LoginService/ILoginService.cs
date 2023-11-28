using ToDoListApi.Data.Entities;
using ToDoListApi.Models;

namespace ToDoListApi.Services.LoginService
{
    public interface ILoginService
    {
        Task<User?> IsExists(LoginModel login);
        UserModel Login(User user, LoginModel login);
    }
}

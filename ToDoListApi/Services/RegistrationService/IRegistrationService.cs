using ToDoListApi.Models;

namespace ToDoListApi.Services.RegistrationService
{
    public interface IRegistrationService
    {
        Task<bool> IsExists(RegisterModel user);
        Task<UserModel> Registration(RegisterModel user);
        
    }
}

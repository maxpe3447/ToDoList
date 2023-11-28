using System.ComponentModel.DataAnnotations;

namespace ToDoListApi.Models
{
    public class UserModel
    {
        public string Username { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}

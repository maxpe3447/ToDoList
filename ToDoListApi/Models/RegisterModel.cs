using System.ComponentModel.DataAnnotations;

namespace ToDoListApi.Models
{
    public class RegisterModel
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}

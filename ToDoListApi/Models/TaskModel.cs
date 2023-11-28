using ToDoListApi.Data.Entities;

namespace ToDoListApi.Models
{
    public class TaskModel
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsDone { get; set; } = false;
        public int UserId { get; set; }
    }
}

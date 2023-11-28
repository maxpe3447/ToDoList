namespace ToDoListApi.Data.Entities;

public class Task : IEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreatedDate { get; set;}
    public bool IsDone { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
}

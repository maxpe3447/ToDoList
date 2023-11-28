namespace ToDoListApi.Data.Entities;

public class User : IEntity
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public byte[] PasswordHash { get; set; } = null!;
    public byte[] PasswordSalt { get; set; } = null!;

    public List<Task> Tasks { get; set; } = new();
}

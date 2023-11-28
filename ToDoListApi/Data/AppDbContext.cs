using Microsoft.EntityFrameworkCore;
using ToDoListApi.Data.Entities;

namespace ToDoListApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options):base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Entities.Task> Tasks { get; set; }
}

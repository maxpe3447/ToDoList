using ToDoListApi.Data.Entities;
using ToDoListApi.Models;

namespace ToDoListApi.Extensions;

public static class TaskModelExtensions
{
    public static Data.Entities.Task ToDataTask(this TaskModel task)
    {
        return new Data.Entities.Task
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description ?? string.Empty,
            IsDone = task.IsDone,
            UserId = task.UserId,
        };
    }
}

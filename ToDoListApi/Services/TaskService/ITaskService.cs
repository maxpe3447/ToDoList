using ToDoListApi.Models;

namespace ToDoListApi.Services.TaskService
{
    public interface ITaskService
    {
        Task<Data.Entities.Task> Create(TaskModel taskModel, int userId);
        Task Edit(TaskModel taskModel);
        Task Delete(TaskModel taskModel);
        IQueryable<Data.Entities.Task> GetAllByUserId(int userId);
        Task<Data.Entities.Task> GetById(int id);
    }
}

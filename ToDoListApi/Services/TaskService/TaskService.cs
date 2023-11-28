using ToDoListApi.Data;
using ToDoListApi.Extensions;
using ToDoListApi.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoListApi.Services.TaskService
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _appDbContext;

        public TaskService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Data.Entities.Task> Create(TaskModel taskModel, int userId)
        {
            var task = taskModel.ToDataTask();
            task.UserId = userId;
            task.CreatedDate = DateTime.UtcNow;
            await _appDbContext.Tasks.AddAsync(task);
            await _appDbContext.SaveChangesAsync();
            return task;
        }

        public async Task Delete(TaskModel taskModel)
        {
            _appDbContext.Tasks.Remove(new Data.Entities.Task { Id = taskModel.Id});
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Edit(TaskModel taskModel)
        {
            var dt = taskModel.ToDataTask();
            _appDbContext.Entry(dt).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<Data.Entities.Task> GetAllByUserId(int userId)
        {
            return _appDbContext.Tasks.Where(x => x.UserId == userId);
        }

        public async Task<Data.Entities.Task?> GetById(int id)
        {
            return await _appDbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

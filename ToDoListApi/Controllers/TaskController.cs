using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using ToDoListApi.Models;
using ToDoListApi.Services.TaskService;

namespace ToDoListApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TaskController:ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost("add")]
    public async Task<ActionResult<Data.Entities.Task>> AddTask(TaskModel taskModel)
    {
        int userId = int.Parse(User.Claims.FirstOrDefault(x=> x.Type == "UserId")?.Value ?? "0");
        if(userId == 0)
        {
            return BadRequest("Invalid Token");
        }
        var task = await _taskService.Create(taskModel, userId);
        return task;
    }

    [HttpPost("edit")]
    public async Task<ActionResult> Edit(TaskModel taskModel)
    {
        int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value ?? "0");
        if (userId == 0)
        {
            return BadRequest("Invalid Token");
        }
        taskModel.UserId = userId;
        await _taskService.Edit(taskModel);
        return Ok();
    }

    [HttpPost("delete")]
    public async Task<ActionResult> Delete(TaskModel taskModel)
    {
        await _taskService.Delete(taskModel);
        return Ok();
    }

    [HttpPost("get_by_id/{id}")]
    public async Task<ActionResult<Data.Entities.Task?>> GetById(int id)
    {
        return await _taskService.GetById(id);
    }
    
    [HttpGet("get_all")]
    public IQueryable<Data.Entities.Task> GetAllTasks()
    {
        int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value ?? "0");
        if (userId == 0)
        {
            return Enumerable.Empty<Data.Entities.Task>().AsQueryable();
        }
        
        return _taskService.GetAllByUserId(userId);
    }
}

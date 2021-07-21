using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskMasterVue.Models;
using TaskMasterVue.Services;

namespace TaskMasterVue.Controllers
{
  [ApiController]
  [Route("api/[Controller]")]
  public class TasksController : ControllerBase
  {
    private readonly TasksService _ts;

    public TasksController(TasksService ts)
    {
      _ts = ts;
    }
    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<TaskModel>> GetOne(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        TaskModel task = _ts.GetOne(userInfo.Id, id);
        return Ok(task);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<TaskModel>> Create([FromBody] TaskModel taskData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        taskData.CreatorId = userInfo.Id;
        TaskModel task = _ts.Create(taskData);
        return Ok(task);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<TaskModel>> Update(int id, [FromBody] TaskModel taskData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        taskData.Id = id;
        TaskModel task = _ts.Update(userInfo.Id, taskData);
        return Ok(task);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        string task = _ts.Delete(userInfo.Id, id);
        return Ok(task);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
using System.Collections.Generic;
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
  public class ListsController : ControllerBase
  {
    private readonly ListsService _ls;
    private readonly TasksService _ts;

    public ListsController(ListsService ls, TasksService ts)
    {
      _ls = ls;
      _ts = ts;
    }
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<ListModel>>> GetAll()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<ListModel> lists = _ls.GetAll(userInfo.Id);
        return Ok(lists);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<ListModel>> GetOne(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        ListModel list = _ls.GetOne(id, userInfo.Id);
        return Ok(list);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/tasks")]
    [Authorize]
    public async Task<ActionResult<List<TaskModel>>> GetTasks(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<TaskModel> tasks = _ts.GetTasks(id, userInfo.Id);
        return Ok(tasks);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ListModel>> Create([FromBody] ListModel listData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        listData.CreatorId = userInfo.Id;
        ListModel list = _ls.Create(listData);
        return Ok(list);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<ListModel>> Update([FromBody] ListModel list, int id)
    {
      try
      {
        list.Id = id;
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        ListModel updatedList = _ls.UpdateList(list, userInfo.Id);
        return Ok(updatedList);
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
        string result = _ls.Delete(id, userInfo.Id);
        return Ok(result);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
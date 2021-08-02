using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using TaskMasterVue.Models;

namespace TaskMasterVue.Repositories
{
  public class TasksRepository
  {
    private readonly IDbConnection _db;

    public TasksRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<TaskModel> GetTasks(int listId)
    {
      var sql = "SELECT * FROM tasks WHERE listId = @listId;";
      return _db.Query<TaskModel>(sql, new { listId }).ToList();

    }

    internal TaskModel Create(TaskModel taskData)
    {
      var sql = "INSERT INTO tasks(title, completed, creatorId, listId) VALUES(@Title,@Completed, @CreatorId, @ListId); SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, taskData);
      taskData.Id = id;
      return taskData;
    }

    internal TaskModel GetOne(int taskId)
    {
      var sql = "SELECT * FROM tasks WHERE id = @taskId;";
      return _db.QueryFirstOrDefault<TaskModel>(sql, new { taskId });
    }

    internal List<TaskModel> GetAll(string id)
    {
      var sql = "SELECT * FROM tasks WHERE creatorId = @id;";
      return _db.Query<TaskModel>(sql, new { id }).ToList();
    }

    internal int Update(TaskModel taskData)
    {
      var sql = "UPDATE tasks SET title = @Title, completed = @Completed, listId = @ListId WHERE id = @Id;";
      return _db.Execute(sql, taskData);
    }

    internal int Delete(int taskId)
    {
      var sql = "DELETE FROM tasks WHERE id = @taskId;";
      return _db.Execute(sql, new { taskId });
    }
  }
}
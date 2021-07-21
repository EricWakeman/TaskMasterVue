using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using TaskMasterVue.Models;

namespace TaskMasterVue.Repositories
{
  public class ListsRepository
  {
    private readonly IDbConnection _db;

    public ListsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<ListModel> GetAll(string id)
    {
      var sql = "SELECT * FROM lists WHERE creatorId = @id;";
      return _db.Query<ListModel>(sql, new { id }).ToList();
    }

    internal ListModel GetOne(int listId)
    {
      var sql = "SELECT * FROM lists WHERE id = @listId;";
      return _db.QueryFirstOrDefault<ListModel>(sql, new { listId });
    }

    internal ListModel Create(ListModel listData)
    {
      var sql = "INSERT INTO lists(title, creatorId) VALUES(@Title, @CreatorId); SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, listData);
      listData.Id = id;
      return listData;
    }
    internal int Update(ListModel listData)
    {
      var sql = "UPDATE lists SET title = @Title WHERE id = @Id;";
      int updated = _db.Execute(sql, listData);
      return updated;
    }


    internal int Delete(int listId)
    {
      var sql = "DELETE FROM lists WHERE id = @listId;";
      int deleted = _db.Execute(sql, new { listId });
      return deleted;
    }
  }
}
using System;
using System.Collections.Generic;
using TaskMasterVue.Models;
using TaskMasterVue.Repositories;

namespace TaskMasterVue.Services
{
  public class ListsService
  {
    private readonly ListsRepository _lr;

    public ListsService(ListsRepository lr)
    {
      _lr = lr;
    }

    internal List<ListModel> GetAll(string id)
    {
      List<ListModel> lists = _lr.GetAll(id);
      return lists;
    }

    internal ListModel GetOne(int listId, string userId)
    {
      ListModel list = _lr.GetOne(listId);
      if (list == null)
      {
        throw new Exception("Invalid List Id.");
      }
      if (list.CreatorId != userId)
      {
        throw new Exception("You do not have permission to view this List.");
      }
      return list;

    }

    internal ListModel UpdateList(ListModel listData, string userId)
    {
      ListModel list = _lr.GetOne(listData.Id);
      if (list == null)
      {
        throw new Exception("Invalid List Id.");
      }
      if (list.CreatorId != userId)
      {
        throw new Exception("You do not have permission to update this List.");
      }
      listData.Title = listData.Title ?? list.Title;
      int updated = _lr.Update(listData);
      if (updated != 1)
      {
        throw new Exception("Failed to update.");
      }
      return listData;
    }

    internal ListModel Create(ListModel listData)
    {
      ListModel newList = _lr.Create(listData);
      return newList;
    }

    internal string Delete(int listId, string userId)
    {
      ListModel list = _lr.GetOne(listId);
      if (list == null)
      {
        throw new Exception("Invalid List Id.");
      }
      if (list.CreatorId != userId)
      {
        throw new Exception("You do not have permission to delete this List.");
      }
      int deleted = _lr.Delete(listId);
      if (deleted != 1)
      {
        throw new Exception("Failed to delete.");
      }
      return "Successfully Deleted";
    }
  }
}
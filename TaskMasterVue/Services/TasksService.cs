using System;
using System.Collections.Generic;
using TaskMasterVue.Models;
using TaskMasterVue.Repositories;

namespace TaskMasterVue.Services
{
  public class TasksService
  {
    private readonly TasksRepository _tr;
    private readonly ListsRepository _lr;

    public TasksService(TasksRepository tr, ListsRepository lr)
    {
      _tr = tr;
      _lr = lr;
    }

    internal List<TaskModel> GetTasks(int listId, string userId)
    {
      ListModel parentList = _lr.GetOne(listId);
      if (parentList.CreatorId != userId)
      {
        throw new Exception("You do not have permission to view this lists tasks.");
      }
      if (parentList == null)
      {
        throw new Exception("Invalid list Id");
      }
      List<TaskModel> tasks = _tr.GetTasks(listId);
      return tasks;

    }

    internal TaskModel Create(TaskModel taskData)
    {
      TaskModel newTask = _tr.Create(taskData);
      return newTask;
    }

    internal TaskModel GetOne(string userId, int taskId)
    {
      TaskModel task = _tr.GetOne(taskId);
      if (task.CreatorId != userId)
      {
        throw new Exception("You do not have permission to view this lists tasks.");
      }
      if (task == null)
      {
        throw new Exception("Invalid task id.");
      }
      return task;
    }

    internal TaskModel Update(string userId, TaskModel taskData)
    {
      taskData.CreatorId = userId;
      TaskModel original = _tr.GetOne(taskData.Id);
      if (original.CreatorId != userId)
      {
        throw new Exception("You do not have permission to update this task.");
      }
      if (original == null)
      {
        throw new Exception("Invalid task id.");
      }
      taskData.ListId = original.ListId;
      taskData.Title = taskData.Title ?? original.Title;
      int updated = _tr.Update(taskData);
      if (updated != 1)
      {
        throw new Exception("Failed to update.");
      }
      return _tr.GetOne(taskData.Id);
    }

    internal string Delete(string userId, int taskId)
    {
      TaskModel original = _tr.GetOne(taskId);
      if (original.CreatorId != userId)
      {
        throw new Exception("You do not have permission to delete this task.");
      }
      if (original == null)
      {
        throw new Exception("Invalid task id.");
      }
      int deleted = _tr.Delete(taskId);
      if (deleted != 1)
      {
        return "Failed to delete.";
      }
      return "Successfully deleted.";

    }
  }
}
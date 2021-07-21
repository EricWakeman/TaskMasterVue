using System;
using TaskMasterVue.Interfaces;

namespace TaskMasterVue.Models
{
  public class TaskModel : IDbItem
  {
    public int Id { get; set; }
    public int ListId { get; set; }
    public string Title { get; set; }
    public string CreatorId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool Completed { get; set; }
  }
}
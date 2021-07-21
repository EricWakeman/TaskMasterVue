using System;
using TaskMasterVue.Interfaces;

namespace TaskMasterVue.Models
{
  public class ListModel : IDbItem
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string CreatorId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Account Profile { get; set; }
  }
}
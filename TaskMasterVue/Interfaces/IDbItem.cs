using System;

namespace TaskMasterVue.Interfaces
{
  public interface IDbItem
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string CreatorId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}
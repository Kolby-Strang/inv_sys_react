namespace inv_sys_react.Models;

public class PermissionTie
{
  public int Id { get; set; }
  public int LocationId { get; set; }
  public string UserId { get; set; }
  public int PermissionLevel { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}

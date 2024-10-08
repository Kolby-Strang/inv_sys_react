namespace inv_sys_react.Models;

public class Account
{
  public string Id { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
  public string Picture { get; set; }
  public int DefaultLocation { get; set; }
  public string IsArchived { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}

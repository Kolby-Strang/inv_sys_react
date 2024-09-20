namespace inv_sys_react.Models;

public class ReceivedItem
{
  public int Id { get; set; }
  public int LocationId { get; set; }
  public int ItemId { get; set; }
  public string ReceivingUserId { get; set; }
  public DateTime CreatedAt { get; set; }
}

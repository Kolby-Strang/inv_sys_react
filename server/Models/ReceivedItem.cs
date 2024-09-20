namespace inv_sys_react.Models;

public class ReceivedItem
{
  public string Id { get; set; }
  public string LocationId { get; set; }
  public string ItemId { get; set; }
  public string ReceivingUserId { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

}

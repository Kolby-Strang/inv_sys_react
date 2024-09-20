namespace inv_sys_react.Models;

public class Invite
{
    public int Id { get; set; }
    public string IssuingUserId { get; set; }
    public string RecipientUserId { get; set; }
    public int LocationId { get; set; }
    public bool IsArchived { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
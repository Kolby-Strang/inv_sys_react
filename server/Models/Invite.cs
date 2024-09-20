namespace inv_sys_react.Models;

public class Invite
{
    public string Id { get; set; }
    public string IssuingUserId { get; set; }
    public string RecipientUserId { get; set; }
    public string LocationId { get; set; }
    public string IsArchived { get; set; }
    public DateTime CreatedAt { get; set; }
}
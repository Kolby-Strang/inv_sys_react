namespace inv_sys_react.Models;

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CreatorId { get; set; }
    public bool IsArchived { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

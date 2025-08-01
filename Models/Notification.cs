using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaAPI.Models;

[Table("Notifications")]
public class Notification
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

    public string Message { get; set; } = string.Empty;
    public bool IsRead { get; set; }
    public DateTime CreateAt { get; set; }
}
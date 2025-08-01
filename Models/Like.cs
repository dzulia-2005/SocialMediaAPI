using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaAPI.Models;

[Table("Likes")]
public class Like
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
    
    public int PostId { get; set; }
    public Post Post { get; set; }
    
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    
}
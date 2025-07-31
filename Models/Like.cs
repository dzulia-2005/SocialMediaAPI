namespace SocialMediaAPI.Models;

public class Like
{
    public int Id { get; set; }
    
    public int userId { get; set; }
    public User User { get; set; }
    
    public int PostId { get; set; }
    public Post Post { get; set; }
    
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    
}
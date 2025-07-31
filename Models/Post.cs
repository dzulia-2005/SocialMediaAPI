namespace SocialMediaAPI.Models;

public class Post
{
    public int Id { get; set; }
    public string Content { get; set; }
    public string? imageUrl { get; set; }
    
    public string UserId { get; set; }
    public User User { get; set; }
    
    public List<Comment> Comments { get; set; }
    public List<Like> Likes { get; set; }
    
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
}
namespace SocialMediaAPI.Models;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; }
    
    public string userId { get; set; }
    public User User { get; set; }
    
    public int PostId { get; set; }
    public Post Post { get; set; }
    
    public DateTime CreateAt { get; set; }
}
namespace SocialMediaAPI.Models;

public class Follower
{
    public int FollowerId { get; set; }
    public User FollowerUser { get; set; }
    
    public string FollowingId { get; set; }
    public User FollowingUser { get; set; }
    
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    
}
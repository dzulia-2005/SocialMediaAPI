using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaAPI.Models;

[Table("Followers")]
public class Follower
{
    public int Id { get; set; }
    public int FollowerUserId { get; set; }
    public User FollowerUser { get; set; }
    
    public int FollowedUserId { get; set; }
    public User FollowedUser { get; set; }
    
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    
}
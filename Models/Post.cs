using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaAPI.Models;


[Table("Posts")]
public class Post
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public string imageUrl { get; set; } = string.Empty;
    
    public int UserId { get; set; }
    public User User { get; set; }

    public List<Comment> Comments { get; set; } = new List<Comment>();
    public List<Like> Likes { get; set; } =  new List<Like>();
    
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
}
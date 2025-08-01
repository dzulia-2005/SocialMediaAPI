using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaAPI.Models;


[Table("Comments")]
public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    
    public int UserId { get; set; }
    public User User { get; set; }
    
    public int PostId { get; set; }
    public Post Post { get; set; }
    
    public DateTime CreateAt { get; set; }
}
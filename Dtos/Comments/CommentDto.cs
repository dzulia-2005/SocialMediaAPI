using SocialMediaAPI.Models;

namespace SocialMediaAPI.Dtos.Comments;

public class CommentDto
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public int UserId { get; set; }
    public int PostId { get; set; }
    public DateTime CreateAt { get; set; }
}
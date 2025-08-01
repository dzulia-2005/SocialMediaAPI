using SocialMediaAPI.Dtos.Comments;
using SocialMediaAPI.Dtos.Like;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Dtos.Posts;

public class PostDto
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public string imageUrl { get; set; } = string.Empty;
    
    public int UserId { get; set; }
    public User User { get; set; }

    public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
    public List<LikeDto> Likes { get; set; } =  new List<LikeDto>();
    
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
}
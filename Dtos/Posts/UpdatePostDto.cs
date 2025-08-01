namespace SocialMediaAPI.Dtos.Posts;

public class UpdatePostDto
{
    public string Content { get; set; } = string.Empty;
    public string imageUrl { get; set; } = string.Empty;
    public int UserId { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
}
namespace SocialMediaAPI.Dtos.Like;

public class LikeDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
}
namespace SocialMediaAPI.Dtos.Comments;

public class CreateCommentDto
{
    public string Content { get; set; } = string.Empty;
    
    public int UserId { get; set; }
    
}
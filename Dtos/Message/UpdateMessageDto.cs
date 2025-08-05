namespace SocialMediaAPI.Dtos.Message;

public class UpdateMessageDto
{
    public int SenderId { get; set; }
    public string Text { get; set; } = string.Empty;
}
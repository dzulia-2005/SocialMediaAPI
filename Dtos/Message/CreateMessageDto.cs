namespace SocialMediaAPI.Dtos.Message;

public class CreateMessageDto
{
    public int ConversationId { get; set; }
    public int SenderId { get; set; }
    public string Text { get; set; } = string.Empty;
}
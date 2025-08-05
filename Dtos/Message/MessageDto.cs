namespace SocialMediaAPI.Dtos.Message;

public class MessageDto
{
    public int Id { get; set; }
    
    public int ConversationId { get; set; }
    public int SenderId { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool IsRead { get; set; }
    public DateTime? ReadAt { get; set; }
    public DateTime SendAt { get; set; }
}
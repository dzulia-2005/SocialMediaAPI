namespace SocialMediaAPI.Models;

public class Message
{
    public int Id { get; set; }
    
    public int ConversationId { get; set; }
    public Conversation Conversation { get; set; }
    
    public string SenderId { get; set; }
    public User Sender { get; set; }
    
    public string Text { get; set; }
    public bool IsRead { get; set; }
    
    public bool ReadAt { get; set; }
    public DateTime SendAt { get; set; } = DateTime.UtcNow;
}
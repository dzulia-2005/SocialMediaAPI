using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaAPI.Models;

[Table("Messages")]
public class Message
{
    public int Id { get; set; }
    
    public int ConversationId { get; set; }
    public Conversation Conversation { get; set; }
    
    public int SenderId { get; set; }
    public User Sender { get; set; }

    public string Text { get; set; } = string.Empty;
    public bool IsRead { get; set; }
    
    public DateTime ReadAt { get; set; }
    public DateTime SendAt { get; set; } = DateTime.UtcNow;
}
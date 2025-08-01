using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaAPI.Models;

[Table("Conversations")]
public class Conversation
{
    public int Id { get; set; }
    
    public int User1Id { get; set; }
    public User User1 { get; set; }
    
    public int User2Id { get; set; }
    public User User2 { get; set; }
    
    public List<Message> Messages { get; set; }
    
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public DateTime ReadAt { get; set; }
    
}
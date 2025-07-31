namespace SocialMediaAPI.Models;

public class Conversation
{
    public int Id { get; set; }
    
    public string User1Id { get; set; }
    public User User1 { get; set; }
    
    public string User2Id { get; set; }
    public User User2 { get; set; }
    
    public List<Message> Messages { get; set; }
    
    public DateTime CreateAt { get; set; }
    public DateTime ReadAt { get; set; }
    
}
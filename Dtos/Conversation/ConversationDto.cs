namespace SocialMediaAPI.Dtos.Conversation;

public class ConversationDto
{
    public int Id { get; set; }
    public int User1Id { get; set; }
    public int User2Id { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime? ReadAt { get; set; }
}
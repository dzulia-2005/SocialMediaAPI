using SocialMediaAPI.Dtos.Conversation;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Interfaces;

public interface IConversationRepository
{ 
    Task<Conversation> CreateConversationAsync(CreateConversationDto dto);
    Task<List<ConversationDto>> GetConversationsAsync(int userId);
}
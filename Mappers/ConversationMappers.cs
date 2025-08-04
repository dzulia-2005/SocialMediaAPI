using SocialMediaAPI.Dtos.Conversation;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Mappers;

public static class ConversationMappers
{
    public static Conversation ToConversationFromCreate(this CreateConversationDto dto)
    {
        return new Conversation
        {
            User1Id = dto.User1Id,
            User2Id = dto.User2Id
        };
    }

    public static ConversationDto ToConversationDto(this Conversation conversation)
    {
        return new ConversationDto
        {
           User1Id = conversation.User1Id,
           User2Id = conversation.User2Id,
           CreateAt = DateTime.UtcNow
        };
    }
}
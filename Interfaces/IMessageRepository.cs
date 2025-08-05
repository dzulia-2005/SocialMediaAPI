using SocialMediaAPI.Dtos.Message;

namespace SocialMediaAPI.Interfaces;

public interface IMessageRepository
{
    Task<MessageDto> CreateMessageAsync(CreateMessageDto dto);
    Task<MessageDto> DeleteMessageAsync(int id);
    Task<List<MessageDto>> GetMessagesByConversationID(int conversationId);
    Task MarkAsRead(int messageId);
}
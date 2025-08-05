using SocialMediaAPI.Dtos.Message;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Mappers;

public static class MessageMappers
{
    public static MessageDto MessageToDto(this Message message)
    {
        return new MessageDto
        {
            Id = message.Id,
            SenderId = message.SenderId,
            Text = message.Text,
            ReadAt = message.ReadAt,
            SendAt = message.SendAt,
            ConversationId = message.ConversationId,
            IsRead = message.IsRead
        };
    }

    public static Message MessageFromCreate(this CreateMessageDto dto)
    {
        return new Message
        {
            ConversationId = dto.ConversationId,
            SenderId = dto.SenderId,
            Text = dto.Text
        };
    }

    public static Message MessageFromUpdate(this UpdateMessageDto dto)
    {
        return new Message
        {
            Text = dto.Text,
            SenderId = dto.SenderId
        };
    }
}
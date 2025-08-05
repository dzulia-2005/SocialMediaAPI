using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Data;
using SocialMediaAPI.Dtos.Message;
using SocialMediaAPI.Interfaces;
using SocialMediaAPI.Mappers;

namespace SocialMediaAPI.Repository;

public class MessageRepository : IMessageRepository
{
    private readonly ApplicationDbContext _context;

    public MessageRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<MessageDto> CreateMessageAsync(CreateMessageDto dto)
    {
        var message = dto.MessageFromCreate();
        await _context.Messages.AddAsync(message);
        await _context.SaveChangesAsync();
        return message.MessageToDto();
    }

    public async Task<List<MessageDto>> GetMessagesByConversationID(int conversationId)
    {
        var message = await _context.Messages
            .Where(m => m.ConversationId == conversationId)
            .ToListAsync();

        return message.Select(m => m.MessageToDto()).ToList();
    }

    public async Task MarkAsRead(int messageId)
    {
        var message = await _context.Messages.FindAsync(messageId);
        if (message == null && !message.IsRead)
        {
            message.IsRead = true;
            message.ReadAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<MessageDto> DeleteMessageAsync(int Id)
    {
        var message = await _context.Messages.FindAsync(Id);
        return message.MessageToDto();
    }
}
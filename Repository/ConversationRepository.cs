using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Data;
using SocialMediaAPI.Dtos.Conversation;
using SocialMediaAPI.Interfaces;
using SocialMediaAPI.Mappers;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Repository;

public class ConversationRepository : IConversationRepository
{
    private readonly ApplicationDbContext _context;

    public ConversationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Conversation> CreateConversationAsync(CreateConversationDto dto)
    {
        var conversation = dto.ToConversationFromCreate();
        await _context.Conversations.AddAsync(conversation);
        await _context.SaveChangesAsync();
        return conversation;
    }

    public async Task<List<ConversationDto>> GetConversationsAsync(int userId)
    {
        var conversation = await _context.Conversations
            .Where(c => c.User1Id == userId || c.User2Id == userId)
            .ToListAsync();

        return conversation.Select(c => c.ToConversationDto()).ToList();
    }
}
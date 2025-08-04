using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SocialMediaAPI.Dtos.Conversation;
using SocialMediaAPI.Interfaces;

namespace SocialMediaAPI.Controller;

[ApiController]
[Route("api/conversation")]
public class ConversationController : ControllerBase
{
    private readonly IConversationRepository _conversationRepository;

    public ConversationController(IConversationRepository conversationRepository)
    {
        _conversationRepository = conversationRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateConversation([FromBody] CreateConversationDto dto)
    {
        var conversation = await _conversationRepository.CreateConversationAsync(dto);
        return Ok(conversation);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetConversations([FromRoute] int userId)
    {
        var conversations = await _conversationRepository.GetConversationsAsync(userId);
        return Ok(conversations);
    }
}
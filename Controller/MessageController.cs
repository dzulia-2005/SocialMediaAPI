using Microsoft.AspNetCore.Mvc;
using SocialMediaAPI.Dtos.Message;
using SocialMediaAPI.Interfaces;

namespace SocialMediaAPI.Controller;

[ApiController]
[Route("api/Message")]
public class MessageController : ControllerBase
{
    private readonly IMessageRepository _messageRepository;

    public MessageController(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMessage([FromBody] CreateMessageDto dto)
    {
        var message = await _messageRepository.CreateMessageAsync(dto);
        return Ok(message);
    }

    [HttpGet("conversation/{conversationId}")]
    public async Task<ActionResult> GetMessagesByConversation([FromRoute] int conversationId)
    {
        var message = await _messageRepository.GetMessagesByConversationID(conversationId);
        return NoContent();
    }

    [HttpPut("read/{id}")]
    public async Task<IActionResult> MarkAsRead([FromRoute] int id)
    {
        await _messageRepository.MarkAsRead(id);
        return NoContent();
    }
}
using Microsoft.AspNetCore.Mvc;
using SocialMediaAPI.Dtos.Notification;
using SocialMediaAPI.Interfaces;
using SocialMediaAPI.Mappers;

namespace SocialMediaAPI.Controller;
[ApiController]
[Route("api/notification")]
public class NotificationController : ControllerBase
{
    private readonly INotificationRepository _notificationRepository;

    public NotificationController(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserNotfication([FromRoute] int userId)
    {
        var notification = await _notificationRepository.GetNotificationByUserIdAsync(userId);
        var dtoList = notification.Select(n => n.ToNotificationDto());
        return Ok(dtoList);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNotification([FromBody] CreateNotificationDto dto)
    {
        var notification = _notificationRepository.CreateNotification(dto);
        return CreatedAtAction(nameof(GetUserNotfication), new { userId = dto.UserId }, notification);
    }
}
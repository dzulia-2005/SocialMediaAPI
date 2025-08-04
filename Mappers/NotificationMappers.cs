using SocialMediaAPI.Dtos.Notification;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Mappers;

public static class NotificationMappers
{
    public static Notification NotficationFromCreateDto(this CreateNotificationDto dto)
    {
        return new Notification
        {
            UserId = dto.UserId,
            Message = dto.Message,
            IsRead = false,
            CreateAt = DateTime.UtcNow
        };
    }

    public static NotificationDto ToNotificationDto(this Notification notification)
    {
        return new NotificationDto
        {
            Id = notification.Id,
            Message = notification.Message,
            IsRead = notification.IsRead,
            CreateAt = notification.CreateAt,
        };
    }
}
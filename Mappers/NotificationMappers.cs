using SocialMediaAPI.Dtos.Notification;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Mappers;

public static class NotificationMappers
{
    public static Notification NotficationFromCreateDto(this NotificationDto dto)
    {
        return new Notification
        {
            UserId = dto.Id,
            Message = dto.Message,
            IsRead = dto.IsRead,
            CreateAt = dto.CreateAt
        };
    }
}
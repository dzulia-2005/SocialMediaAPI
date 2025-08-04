using SocialMediaAPI.Dtos.Notification;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Interfaces;

public interface INotificationRepository
{
    Task<List<Notification>> GetNotificationByUserIdAsync(int UserId);
    
    Task<Notification> CreateNotification(NotificationDto dto);
}
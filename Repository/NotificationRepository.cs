using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Data;
using SocialMediaAPI.Dtos.Notification;
using SocialMediaAPI.Interfaces;
using SocialMediaAPI.Mappers;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Repository;

public class NotificationRepository : INotificationRepository
{
    private readonly ApplicationDbContext _context;

    public NotificationRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<List<Notification>> GetNotificationByUserIdAsync(int UserId)
    {
        return await _context.Notifications
            .Where(n => n.UserId == UserId)
            .OrderByDescending(x=>x.CreateAt)
            .ToListAsync();
    }


    public async Task<Notification> CreateNotification(NotificationDto dto)
    {
        var notification = dto.NotficationFromCreateDto();
        await _context.Notifications.AddAsync(notification);
        await _context.SaveChangesAsync();
        return notification;
    }
}
using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Data;
using SocialMediaAPI.Dtos.Follower;
using SocialMediaAPI.Dtos.Notification;
using SocialMediaAPI.Interfaces;
using SocialMediaAPI.Mappers;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Repository;

public class FollowerRepository : IFollowerRepository
{
    private readonly ApplicationDbContext _context;
    private readonly INotificationRepository _notificationRepository;
    
    public FollowerRepository(ApplicationDbContext context,INotificationRepository notificationRepository)
    {
        _context = context;
        _notificationRepository = notificationRepository;
    }
    
    public async Task<Follower> CreateFollower(CreateFollowerDto dto)
    {
        var follower = dto.ToFollowerFromCreate();
        await _context.Followers.AddAsync(follower);
        await _context.SaveChangesAsync();

        await _notificationRepository.CreateNotification(new CreateNotificationDto
        {
            UserId = follower.FollowerUserId,
            Message = $"User {follower.FollowerUser} stareted following you."
        });
        
        return follower;
    }

    public async Task<FollowerDto> getFollower(int userId)
    {
        var followerCount = await _context.Followers
            .CountAsync(f => f.FollowedUserId == userId);

        var followingCount = await _context.Followers
            .CountAsync(f => f.FollowerUserId == userId);

        return new FollowerDto
        {
            Followers = followerCount,
            Following = followingCount
        };

    }
}
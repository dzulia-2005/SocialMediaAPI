using SocialMediaAPI.Dtos.Follower;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Mappers;

public static class FollowerMappers
{
    public static Follower ToFollowerFromCreate(this CreateFollowerDto dto)
    {
        return new Follower
        {
            FollowedUserId = dto.FollowedUserId,
            FollowerUserId = dto.FollowerUserId
        };
    }
    
}
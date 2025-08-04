using SocialMediaAPI.Dtos.Follower;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Interfaces;

public interface IFollowerRepository
{
    Task<Follower> CreateFollower(CreateFollowerDto dto);
    Task<FollowerDto> getFollower(int userId);
}
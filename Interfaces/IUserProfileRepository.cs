using SocialMediaAPI.Dtos.UserProfile;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Interfaces;

public interface IUserProfileRepository
{
    Task<User?> UpdateProfileAsync(string userId,UpdateProfileDto user);
}
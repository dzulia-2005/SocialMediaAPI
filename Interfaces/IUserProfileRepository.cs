using SocialMediaAPI.Models;

namespace SocialMediaAPI.Interfaces;

public interface IUserProfileRepository
{
    Task<User> UpdateProfileAsync(User user);
}
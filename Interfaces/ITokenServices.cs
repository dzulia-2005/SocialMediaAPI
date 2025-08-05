using SocialMediaAPI.Models;

namespace SocialMediaAPI.Interfaces;

public interface ITokenServices
{
    string CreateToken(User user);
}
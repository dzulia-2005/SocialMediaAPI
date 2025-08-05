using SocialMediaAPI.Models;

namespace SocialMediaAPI.Interfaces;

public interface ITokenServices
{
    string CreateToken(User user);
    string GenerateRefreshToken();
    Task<string> GenerateandSaveRefreshToken(User user);
}
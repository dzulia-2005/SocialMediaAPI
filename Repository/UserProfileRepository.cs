using SocialMediaAPI.Data;
using SocialMediaAPI.Interfaces;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Repository;

public class UserProfileRepository : IUserProfileRepository
{
    private readonly ApplicationDbContext _context;

    public UserProfileRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<User> UpdateProfileAsync(User user)
    {
        var existUser = await _context.Users.FindAsync(user.Id);
        if (user==null)
        {
            return null;
        }

        existUser.UserName = user.UserName;
        existUser.Bio = user.Bio;
        existUser.ProfilePicture = user.ProfilePicture;

        await _context.SaveChangesAsync();
        return existUser;
    }
}
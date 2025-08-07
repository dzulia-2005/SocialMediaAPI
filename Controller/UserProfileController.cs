using Microsoft.AspNetCore.Mvc;
using SocialMediaAPI.Interfaces;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Controller;
[ApiController]
[Route("api/Profile")]
public class UserProfileController : ControllerBase
{
    private readonly IUserProfileRepository _userProfileRepository;

    public UserProfileController(IUserProfileRepository userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }

    [HttpPut("UpdateProfile")]
    public async Task<IActionResult> UpdateProfile(User user)
    {
        var ExistUser = await _userProfileRepository.UpdateProfileAsync(user);
        if (ExistUser==null)
        {
            return Unauthorized();
        }

        return Ok(ExistUser);
    }
}
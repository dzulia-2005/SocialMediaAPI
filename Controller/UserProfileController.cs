using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SocialMediaAPI.Dtos.UserProfile;
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
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        var ExistUser = await _userProfileRepository.UpdateProfileAsync(userId,dto);
        if (ExistUser==null)
        {
            return Unauthorized();
        }

        return Ok(ExistUser);
    }
}
using System.Security.Claims;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Data;
using SocialMediaAPI.Dtos.Auth;
using SocialMediaAPI.Interfaces;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Controller;
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenServices _services;
    private readonly ApplicationDbContext _context;

    public AuthController(SignInManager<User> signInManager, UserManager<User> userManager,ITokenServices services,ApplicationDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _services = services;
        _context = context;
    }

    [Route("login")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        try
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName);
            if (user == null)
            {
                return Unauthorized();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized("password or username is invalid");
            }

            var token = _services.CreateToken(user);
            var refreshToken = await _services.GenerateandSaveRefreshToken(user);

            return Ok(
                new NewUserDto
                {
                    AccessToken = token,
                    RefreshToken = refreshToken
                }
            );

        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }

    [Route("register")]
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerdto)
    {
        try
        {
            var user = new User
            {
                UserName = registerdto.UserName,
                Email = registerdto.Email
            };

            var accesstoken = _services.CreateToken(user);
            var refreshToken = await _services.GenerateandSaveRefreshToken(user);
            
            var createResult = await _userManager.CreateAsync(user, registerdto.Password);
            if (createResult.Succeeded)
            {
                var RoleResult = await _userManager.AddToRoleAsync(user, "USER");
                if (RoleResult.Succeeded)
                {
                    return Ok(new NewUserDto
                    {
                        AccessToken = accesstoken,
                        RefreshToken = refreshToken
                    });
                }
                else
                {
                    return StatusCode(500, RoleResult.Errors);
                }
            }
            else
            {
                return StatusCode(500, createResult.Errors);
            }
        }
        catch (Exception e)
        {
            return StatusCode(500, new {error = e.Message,stack = e.StackTrace});
        }
    }

    [HttpGet("me")]
    public async Task<IActionResult> Me()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId==null)
        {
            return Unauthorized("user is not found");
        }

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return Unauthorized("user is not found");
        }

        var userDto = new
        {
            Id = user.Id,
            UserName = user.UserName,
            mail = user.Email,
            ProfilePicture = user.ProfilePicture,
            Bio = user.Bio,
            CreateAt = user.CreateAt,
        };

        return Ok(userDto);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest refreshRequest)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshRequest.RefreshToken);
        if (user == null || user.RefreshTokenExpiry > DateTime.UtcNow )
        {
            return Unauthorized("invalid or expired refresh token ");
        }

        var NewAccessToken = _services.CreateToken(user);
        var NewRefreshToken = _services.GenerateandSaveRefreshToken(user);

        return Ok(
            new
            {
                AccessToken = NewAccessToken,
                RefreshToken = NewRefreshToken
            }
        );
    }

    [HttpPost("logout")]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return Ok(new {message = "Signed out successfully"});
    }
}
using System.ComponentModel.DataAnnotations;

namespace SocialMediaAPI.Dtos.Auth;

public class RegisterDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}
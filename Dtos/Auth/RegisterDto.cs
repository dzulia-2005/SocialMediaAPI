using System.ComponentModel.DataAnnotations;

namespace SocialMediaAPI.Dtos.Auth;

public class RegisterDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string mail { get; set; }
    [Required]
    public string Password { get; set; }
}
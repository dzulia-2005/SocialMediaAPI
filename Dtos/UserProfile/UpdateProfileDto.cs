namespace SocialMediaAPI.Dtos.UserProfile;

public class UpdateProfileDto
{
    public string UserName { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string ProfilePicture { get; set; } = string.Empty;
}
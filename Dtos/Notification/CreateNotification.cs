namespace SocialMediaAPI.Dtos.Notification;

public class CreateNotification
{
    public int UserId { get; set; }
    public string Message { get; set; } = string.Empty;
}
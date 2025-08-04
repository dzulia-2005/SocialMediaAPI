namespace SocialMediaAPI.Dtos.Notification;

public class NotificationDto
{
    public int Id { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool IsRead { get; set; }
    public DateTime CreateAt { get; set; }
}
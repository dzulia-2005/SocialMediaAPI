namespace SocialMediaAPI.Models;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string ProfilePicture { get; set; } = string.Empty;

    public List<Post> Posts { get; set; } = new List<Post>();
    public List<Comment> Comments { get; set; } = new List<Comment>();
    public List<Like> Likes { get; set; } =  new List<Like>();
    public List<Notification> Notifications { get; set; } = new List<Notification>();
    
    public List<Follower> Followers { get; set; }=  new List<Follower>();
    public List<Follower> Following { get; set; }=  new List<Follower>();
    public List<Message> SentMessages { get; set; } = new List<Message>();
    
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
}
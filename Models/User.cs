namespace SocialMediaAPI.Models;

public class User
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
    public string ProfilePicture { get; set; }

    public List<Post> Posts { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Like> Likes { get; set; }
    
    public List<Follower> Followers { get; set; }
    public List<Follower> Following { get; set; }
    
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
}
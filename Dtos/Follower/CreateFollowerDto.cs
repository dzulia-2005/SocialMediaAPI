namespace SocialMediaAPI.Dtos.Follower;

public class CreateFollowerDto
{
    public int FollowerUserId { get; set; }
    public int FollowedUserId { get; set; }
}
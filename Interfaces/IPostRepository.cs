using SocialMediaAPI.Dtos.Posts;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Interfaces;

public interface IPostRepository
{
    Task<List<Post>> GetPostsAsync();
    Task<Post> GetPostByIdAsync(int Id);
    Task<Post> CreatePostAsync(CreatePostDto postDto);
}
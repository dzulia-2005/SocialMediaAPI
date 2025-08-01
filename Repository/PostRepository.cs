using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Data;
using SocialMediaAPI.Interfaces;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Repository;

public class PostRepository : IPostRepository
{
    private readonly ApplicationDbContext _Context;

    public PostRepository(ApplicationDbContext context)
    {
        _Context = context;
    }

    public async Task<List<Post>> GetPostsAsync()
    {
        var posts = _Context.Posts.Include(x => x.User).ToList();
        return posts;
    }

    public async Task<Post> GetPostByIdAsync(int Id)
    {
        var post = await _Context.Posts.FindAsync(Id);
        return post;
    }
}
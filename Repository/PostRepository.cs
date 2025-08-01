using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Data;
using SocialMediaAPI.Dtos.Posts;
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

    public async Task<Post> CreatePostAsync(CreatePostDto postDto)
    {
        var user = await _Context.Users.FindAsync(postDto.UserId);
        if (user==null)
        {
            throw new Exception("user not found");
        }

        var post = new Post
        {
            Content = postDto.Content,
            imageUrl = postDto.imageUrl,
            UserId = postDto.UserId,
            CreateAt = postDto.CreateAt,
            User = user,
        };

        _Context.Posts.Add(post);
        await _Context.SaveChangesAsync();
        return post;
    }

    public async Task<Post> UpdatePostAsync(int Id,UpdatePostDto updatePostDto)
    {
        var existingPost = await _Context.Posts.FindAsync(Id);
        if (existingPost==null)
        {
            return null;
        }

        existingPost.Content = updatePostDto.Content;
        existingPost.imageUrl = updatePostDto.imageUrl;
        existingPost.UserId = updatePostDto.UserId;
        existingPost.CreateAt = updatePostDto.CreateAt;

        await _Context.SaveChangesAsync();
        return existingPost;
    }
}
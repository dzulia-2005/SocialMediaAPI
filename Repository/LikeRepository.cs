using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Data;
using SocialMediaAPI.Dtos.Like;
using SocialMediaAPI.Dtos.Posts;
using SocialMediaAPI.Interfaces;
using SocialMediaAPI.Mappers;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Repository;

public class LikeRepository : ILikeRepository
{
    private readonly ApplicationDbContext _context;

    public LikeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Like> CreateLikeAsync(CreateLikeDto likeDto)
    {
        var like = likeDto.LikefromCreateDto();
        _context.Likes.Add(like);
        await _context.SaveChangesAsync();
        return like;
    }

    public async Task<Like> DeleteLikeAsync(int UserId, int PostId)
    {
        var like = await _context.Likes.FirstOrDefaultAsync(l => l.UserId == UserId && l.PostId == PostId);
        if (like==null)
        {
            return null;
        }

        _context.Likes.Remove(like);
        await _context.SaveChangesAsync();
        return like;
    }

    public async Task<List<Like>> GetLikesByPostIdAsync(int PostId)
    {
        return await _context.Likes
            .Where(l => l.PostId == PostId)
            .ToListAsync();
    }
    
}
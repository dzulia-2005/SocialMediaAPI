using SocialMediaAPI.Data;
using SocialMediaAPI.Dtos.Like;
using SocialMediaAPI.Dtos.Posts;
using SocialMediaAPI.Interfaces;
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
        
    }
}
using SocialMediaAPI.Dtos.Like;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Interfaces;

public interface ILikeRepository
{
    Task<Like> CreateLikeAsync(CreateLikeDto likeDto);
    Task<Like> DeleteLikeAsync(int UserId, int PostId);
    Task<List<Like>> GetLikesByPostIdAsync(int PostId);
}
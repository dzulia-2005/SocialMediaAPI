using SocialMediaAPI.Dtos.Comments;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Interfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllCommentsAsync();
    Task<Comment?> GetCommentByIdAsync(int Id);
    Task<Comment?> CreateCommentAsync(Comment comment);
}
using SocialMediaAPI.Dtos.Comments;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Interfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllCommentsAsync();
    Task<Comment?> GetCommentByIdAsync(int Id);
    Task<Comment?> CreateCommentAsync(Comment comment);
    Task<Comment?> UpdateCommentAsync(int Id, Comment comment);
    Task<Comment?> DeleteCommentAsync(int Id);
}
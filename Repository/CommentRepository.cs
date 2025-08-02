using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Data;
using SocialMediaAPI.Dtos.Comments;
using SocialMediaAPI.Interfaces;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Repository;

public class CommentRepository : ICommentRepository
{
    private readonly ApplicationDbContext _context;

    public CommentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Comment>> GetAllCommentsAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comment?> GetCommentByIdAsync(int Id)
    {
        return await _context.Comments.FindAsync(Id);
    }


    public async Task<Comment?> CreateCommentAsync(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task<Comment?> UpdateCommentAsync(int Id, Comment comment)
    {
        var existingComment = await _context.Comments.FindAsync(Id);
        if (existingComment == null)
        {
            return null;
        }

        existingComment.Content = comment.Content;
        await _context.SaveChangesAsync();

        return existingComment;
    }

    public async Task<Comment?> DeleteCommentAsync(int Id)
    {
        var comment = await _context.Comments.FindAsync(Id);
        return comment;
    }
}
using SocialMediaAPI.Dtos.Comments;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Mappers;

public static  class CommentMappers
{
    public static CommentDto ToCommentDto(this Comment commentmodel)
    {
        return new CommentDto
        {
            Id = commentmodel.Id,
            UserId = commentmodel.UserId,
            PostId = commentmodel.PostId,
            CreateAt = commentmodel.CreateAt,
            Content = commentmodel.Content
        };
    }
}
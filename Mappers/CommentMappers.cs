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

    public static Comment ToCommentFromCreate(this CreateCommentDto commentmodel,int PostId)
    {
        return new Comment
        {
            Content = commentmodel.Content,
            UserId = commentmodel.UserId,
            PostId = PostId,
            CreateAt = commentmodel.CreateAt
        };
    }

    public static Comment ToCommentFromUpdate(this UpdateCommentDto commentmodel,int Id)
    {
        return new Comment
        {
            Content = commentmodel.Content,
            UserId = commentmodel.UserId,
            PostId = Id,
            CreateAt = commentmodel.CreateAt
        };
    }
    
}
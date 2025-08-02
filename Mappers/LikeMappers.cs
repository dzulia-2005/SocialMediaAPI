using SocialMediaAPI.Dtos.Like;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Mappers;

public static class LikeMappers
{
    public static LikeDto LikeToDto(this Like likemodel)
    {
        return new LikeDto
        {
            Id = likemodel.Id,
            UserId = likemodel.UserId,
            PostId = likemodel.PostId,
            CreateAt = likemodel.CreateAt
        };
    }

    public static Like LikefromCreateDto(this CreateLikeDto likeDto)
    {
        return new Like
        {
            UserId = likeDto.UserId,
            PostId = likeDto.PostId
        };
    }
}
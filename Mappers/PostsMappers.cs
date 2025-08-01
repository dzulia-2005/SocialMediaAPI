using SocialMediaAPI.Dtos.Posts;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Mappers;

public static class  PostsMappers
{
    public static PostDto ToPostDto(this Post postmodel)
    {
        return new PostDto
        {
            Id = postmodel.Id,
            Content = postmodel.Content,
            CreateAt = postmodel.CreateAt,
            imageUrl = postmodel.imageUrl,
            UserId = postmodel.UserId,
            Likes = postmodel.Likes.Select(s=>s.LikeToDto()).ToList()
            
        };
    } 
}
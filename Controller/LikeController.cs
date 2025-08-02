using Microsoft.AspNetCore.Mvc;
using SocialMediaAPI.Dtos.Like;
using SocialMediaAPI.Interfaces;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Controller;

[ApiController]
[Route("api/Like")]
public class LikeController : ControllerBase
{
    private readonly ILikeRepository _Likerepository;

    public LikeController(ILikeRepository Likerepository)
    {
        _Likerepository = Likerepository;
    }

    [HttpPost("createlike")]
    public async Task<IActionResult> CreateLike([FromBody] CreateLikeDto dto)
    {
        var like = await _Likerepository.CreateLikeAsync(dto);
        return CreatedAtAction(nameof(GetLikeForPost), new { PostId = like.PostId }, like);
    }

    [HttpDelete("deletelike")]
    public async Task<IActionResult> RemoveLike([FromQuery] int UserId, [FromQuery] int PostId)
    {
        var result = await _Likerepository.DeleteLikeAsync(UserId, PostId);
        if (result==null)
        {
            return NotFound("Like not found");
        }

        return NoContent();
    }

    [HttpGet("post/{postId:int}")]
    public async Task<IActionResult> GetLikeForPost([FromRoute] int postId)
    {
        var likes = await _Likerepository.GetLikesByPostIdAsync(postId);
        return Ok(likes);
    }
    
    
}
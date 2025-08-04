using Microsoft.AspNetCore.Mvc;
using SocialMediaAPI.Dtos.Follower;
using SocialMediaAPI.Interfaces;

namespace SocialMediaAPI.Controller;
[ApiController]
[Route("api/follower")]
public class FollowerController : ControllerBase
{
    private readonly IFollowerRepository _followerRepository;

    public FollowerController(IFollowerRepository followerRepository)
    {
        _followerRepository = followerRepository;
    }
    
    [HttpPost("createfollowing")]
    public async Task<IActionResult> CreateFollower([FromBody] CreateFollowerDto dto)
    {
        var follower = await _followerRepository.CreateFollower(dto);
        return Ok(follower);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetFollowers([FromRoute] int userId)
    {
        var follower = await _followerRepository.getFollower(userId);
        return Ok(follower);
    }
    
    
}
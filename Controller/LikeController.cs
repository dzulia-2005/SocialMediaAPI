using Microsoft.AspNetCore.Mvc;
using SocialMediaAPI.Interfaces;

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
    public async Task<IActionResult> CreateLike()
    {
        
    }
    
    
}
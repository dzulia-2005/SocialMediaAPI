using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Data;
using SocialMediaAPI.Interfaces;
using SocialMediaAPI.Mappers;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Controller;

[ApiController]
[Route("api/post")]
public class PostController : ControllerBase
{
    private readonly IPostRepository _postRepository;

    public PostController(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    [HttpGet]
    public async Task<ActionResult> GetPosts()
    {
        var posts = await _postRepository.GetPostsAsync();
        var postdto = posts.Select(s=>s.ToPostDto());

        return Ok(postdto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetPostById([FromRoute] int Id)
    {
        var post = await _postRepository.GetPostByIdAsync(Id);
        if (post == null)
        {
            return NotFound();
        }

        return Ok(post.ToPostDto());
    }
    
   
}
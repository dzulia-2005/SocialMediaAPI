using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Data;
using SocialMediaAPI.Dtos.Posts;
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

    [HttpGet("{Id:int}")]
    public async Task<ActionResult> GetPostById([FromRoute] int Id)
    {
        var post = await _postRepository.GetPostByIdAsync(Id);
        if (post == null)
        {
            return NotFound();
        }

        return Ok(post.ToPostDto());
    }

    [HttpPost]
    public async Task<ActionResult> CreatePost([FromBody] CreatePostDto postDto)
    {
        try
        {
            var createdPost = await _postRepository.CreatePostAsync(postDto);
            return CreatedAtAction(nameof(GetPostById), new { Id = createdPost.Id }, createdPost);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
   
}
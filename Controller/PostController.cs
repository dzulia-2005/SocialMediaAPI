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
    public async Task<IActionResult> GetPosts()
    {
        var posts = await _postRepository.GetPostsAsync();
        var postdto = posts.Select(s=>s.ToPostDto());

        return Ok(postdto);
    }

    [HttpGet("{Id:int}")]
    public async Task<IActionResult> GetPostById([FromRoute] int Id)
    {
        var post = await _postRepository.GetPostByIdAsync(Id);
        if (post == null)
        {
            return NotFound();
        }

        return Ok(post.ToPostDto());
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostDto postDto)
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

    [HttpPut("update/{Id:int}")]
    public async Task<IActionResult> UpdatePost([FromRoute] int Id,[FromBody] UpdatePostDto updatePostDto)
    {
        var post = await _postRepository.UpdatePostAsync(Id, updatePostDto);
        if (post == null)
        {
            return NotFound("post not found");
        }

        return Ok(post.ToPostDto());
    }

    [HttpDelete("delete/{Id:int}")]
    public async Task<IActionResult> DeletePost([FromRoute] int Id)
    {
        var post = await _postRepository.DeletePostAsync(Id);
        if (post == null)
        {
            return NotFound("Post is not found");
        }

        return NoContent();
    }
    
   
}
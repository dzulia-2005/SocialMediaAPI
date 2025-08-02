using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SocialMediaAPI.Dtos.Comments;
using SocialMediaAPI.Interfaces;
using SocialMediaAPI.Mappers;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Controller;

[ApiController]
[Route("api/comments")]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository _commentRepository;
    private readonly IPostRepository _postRepository;

    public CommentController(ICommentRepository commentRepository, IPostRepository postRepository)
    {
        _commentRepository = commentRepository;
        _postRepository = postRepository;
    }

    [HttpGet]
    public async Task<IActionResult> getAllComments()
    {
        var comments = await _commentRepository.GetAllCommentsAsync();
        var commentsDto = comments.Select(x => x.ToCommentDto());
        return Ok(commentsDto);
    }

    [HttpGet("{Id:int}")]
    public async Task<IActionResult> getCommentById(int Id)
    {
        var comment = await _commentRepository.GetCommentByIdAsync(Id);
        if (comment == null)
        {
            return NotFound();
        }
        var commentDto = comment.ToCommentDto();

        return Ok(commentDto);
    }

    [HttpPost("{PostId:int}")]
    public async Task<IActionResult> CreateComment([FromRoute] int PostId, CreateCommentDto commentDto)
    {
        var comentModel = commentDto.ToCommentFromCreate(PostId);
        await _commentRepository.CreateCommentAsync(comentModel);
        return CreatedAtAction(nameof(getCommentById), new { Id = comentModel.Id }, comentModel.ToCommentDto());
    }

    [HttpPut("{Id:int}")]
    public async Task<IActionResult> UpdateComment([FromRoute] int Id, [FromBody] UpdateCommentDto commentDto)
    {
        var commentModel = await _commentRepository.UpdateCommentAsync(Id, commentDto.ToCommentFromUpdate());
        if (commentModel == null)
        {
            return NotFound("comment not found");
        }

        return Ok(commentModel.ToCommentDto());
    }

    [HttpDelete("{Id:int}")]
    public async Task<IActionResult> DeleteComment([FromRoute] int Id)
    {
        var comment = await _commentRepository.DeleteCommentAsync(Id);
        return Ok(comment);
    }
    
} 
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Data;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Controller;

[ApiController]
[Route("api/post")]
public class PostController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PostController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
    {
        var posts = await _context.Posts
            .Include(p => p.User)
            .ToListAsync();

        return Ok(posts);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Post>> GetPostById(int id)
    {
        var posts = await _context.Posts.FindAsync(id);
        if (posts == null)
        {
            return NotFound();
        }

        return Ok(posts);
    }
}
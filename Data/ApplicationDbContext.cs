using Microsoft.EntityFrameworkCore;

namespace SocialMediaAPI.Data;

public class ApplicationDbContext : DbContext 
{
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }
}
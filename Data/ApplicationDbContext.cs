using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Data;

public class ApplicationDbContext : IdentityDbContext<User,IdentityRole<int>,int> 
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Follower> Followers { get; set; }
    public DbSet<Conversation> Conversations { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings => 
            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }
   protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Follower>()
            .HasOne(f => f.FollowerUser)
            .WithMany(f => f.Following)
            .HasForeignKey(f => f.FollowerUserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Follower>()
            .HasOne(f => f.FollowedUser)
            .WithMany(f => f.Followers)
            .HasForeignKey(f => f.FollowedUserId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<Conversation>()
            .HasOne(f => f.User1)
            .WithMany()
            .HasForeignKey(f => f.User1Id)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Conversation>()
            .HasOne(f => f.User2)
            .WithMany()
            .HasForeignKey(f => f.User2Id)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Post>()
            .HasOne(p => p.User)
            .WithMany(p => p.Posts)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Like>()
            .HasKey(l => l.Id);

        modelBuilder.Entity<Like>()
            .HasOne(l => l.User)
            .WithMany(l => l.Likes)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Like>()
            .HasOne(l => l.Post)
            .WithMany(l => l.Likes)
            .HasForeignKey(l => l.PostId)
            .OnDelete(DeleteBehavior.NoAction);

        
        modelBuilder.Entity<Notification>()
            .HasOne(n => n.User)
            .WithMany(n => n.Notifications)
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Post)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany(c => c.Comments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<Message>()
            .HasOne(m => m.Conversation)
            .WithMany(m => m.Messages)
            .HasForeignKey(m => m.ConversationId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.Sender)
            .WithMany(m => m.SentMessages)
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.NoAction);

        List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "user",
                NormalizedName = "USER"
            }
        };
        modelBuilder.Entity<IdentityRole>().HasData(roles);
    }
}
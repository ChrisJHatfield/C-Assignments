using Microsoft.EntityFrameworkCore;

namespace The_Wall.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<MessageLiked> MessagesLiked { get; set; }
        public DbSet<CommentLiked> CommentsLiked { get; set; }
    }
}
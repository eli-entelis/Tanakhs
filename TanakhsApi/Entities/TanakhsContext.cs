using Microsoft.EntityFrameworkCore;

namespace TanakhsApi.Entities
{
    public class TanakhsContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Verse> Verses { get; set; }

        public TanakhsContext(DbContextOptions<TanakhsContext> options)
            : base(options) { }
    }
}

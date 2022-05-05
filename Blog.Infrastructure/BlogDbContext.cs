using Blog.Infrastructure.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure
{
    public class BlogDbContext : IdentityDbContext<User>
    {
        public BlogDbContext()
        {}
        public BlogDbContext(DbContextOptions<BlogDbContext> dbContextOptions)
            : base(dbContextOptions)
        { }

        public DbSet<Post> Posts { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;

        public DbSet<Reaction> Reactions { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Blog;Integrated Security=true;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Comment>()
                .HasOne(p => p.Post)
                .WithMany(c => c.Comments)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Post>()
                .HasMany(r => r.Reactions)
                .WithOne(p => p.Post)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Post>()
                .HasMany(c => c.Comments)
                .WithOne(p => p.Post)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}

using Blog.Infrastructure.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure
{
    public class BlogDbContext : IdentityDbContext<User>
    {

        public DbSet<Post>? Posts { get; set; }

        public DbSet<Comment>? Comments { get; set; }

        public DbSet<Reaction>? Reactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Blog;Trusted_Connection=True;MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
    // кур муr qnko
    // янко е хуя ми 
}

using Microsoft.AspNetCore.Identity;

namespace Blog.Infrastructure.Data
{
    public class User : IdentityUser
    {
        public string? ImageProfile { get; set; }

        public ICollection<Post> Posts { get; init; } = new HashSet<Post>();

        public ICollection<Comment> Comments { get; init; } = new HashSet<Comment>();

        public ICollection<Reaction> Reactions { get; init; } = new HashSet<Reaction>();

    }
}

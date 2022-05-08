using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Blog.Infrastructure.Data
{
    public class User : IdentityUser
    {
        [Required]
        public string FullName { get; set; } = null!;

        public string? ImageProfile { get; set; }

        public ICollection<Post> Posts { get; init; } = new HashSet<Post>();

        public ICollection<Comment> Comments { get; init; } = new HashSet<Comment>();

        public ICollection<Reaction> Reactions { get; init; } = new HashSet<Reaction>();

    }
}

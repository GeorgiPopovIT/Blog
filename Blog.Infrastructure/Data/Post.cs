using System.ComponentModel.DataAnnotations;

namespace Blog.Infrastructure.Data
{
    public class Post : BaseModel<int>
    {

        [Required]
        [MaxLength(DataConstants.MaxTitleLength)]
        public string? Title { get; set; }

        [Required]
        public string? Content { get; set; }

        public bool IsVisible { get; set; }

        [Required]
        public string? UserId { get; set; }
        public User User { get; set; }  = null!;

        public ICollection<Comment> Comments { get; init; } = new HashSet<Comment>();

        public ICollection<Image> Images { get; init; } = new HashSet<Image>();

        public ICollection<Reaction> Reactions { get; init; } = new HashSet<Reaction>();
    }
}
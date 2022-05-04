using System.ComponentModel.DataAnnotations;

namespace Blog.Infrastructure.Data
{
    public class Post : BaseModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataModelsConstants.MaxTitleLength)]
        public string? Title { get; set; }

        [Required]
        public string? Content { get; set; }

        public string? PhotoPost { get; set; }

        public bool IsVisible { get; set; }

        [Required]
        public string? UserId { get; set; }
        public User User { get; set; }  = null!;

        public ICollection<Comment> Comments { get; init; } = new HashSet<Comment>();

        public ICollection<Reaction> Reactions { get; init; } = new HashSet<Reaction>();
    }
}
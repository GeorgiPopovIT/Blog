using System.ComponentModel.DataAnnotations;

namespace Blog.Infrastructure.Data
{
    public class Reaction : BaseModel
    {
        public int Id { get; set; }

        //foreign key
        [Required]
        public string? UserId { get; set; }
        public User User { get; set; } = null!;

        [Required]
        public int PostId { get; set; }

        public Post Post { get; set; } = null!;
    }
}

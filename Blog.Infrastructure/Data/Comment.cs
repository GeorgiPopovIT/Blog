using System.ComponentModel.DataAnnotations;

namespace Blog.Infrastructure.Data
{
    public class Comment: BaseModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataModelsConstants.MaxCommentLength)]
        public string? Content { get; set; }

        [Required]
        public int PostId { get; set; }
        public Post? Post { get; set; }

        [Required]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Infrastructure.Data
{
    public class Comment: BaseModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataModelsConstants.MaxCommentLength)]
        public string? Content { get; set; }

        //foreign key
        [Required]
        public string? UserId { get; set; }
        public User User { get; set; } = null!;

        [Required]
        public int PostId { get; set; }

       
        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; } = null!;
    }
}

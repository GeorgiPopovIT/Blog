using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Infrastructure.Data
{
    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        
        public string? ImageName { get; set; } 

        [Required]
        public string? Extension { get; set; }

        public int PostId { get; set; }

        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; } = null!;

        [Required]
        public string? AddedByUserId { get; set; }

        [ForeignKey(nameof(AddedByUserId))]
        public User? AddedByUser { get; set; }

    }
}

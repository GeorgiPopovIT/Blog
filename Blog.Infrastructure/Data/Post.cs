using System.ComponentModel.DataAnnotations;

namespace Blog.Infrastructure.Data
{
    public class Post : BaseModel
    {

        public int Id { get; set; }
       

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Content { get; set; }

    }
}
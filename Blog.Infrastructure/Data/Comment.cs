
namespace Blog.Infrastructure.Data
{
    public class Comment: BaseModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Post PostId { get; set; }
        public Post Post { get; set; }  
    }
}

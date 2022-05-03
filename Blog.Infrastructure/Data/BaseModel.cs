
namespace Blog.Infrastructure.Data
{
    public abstract class BaseModel
    {
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}

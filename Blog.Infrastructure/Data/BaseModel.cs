
namespace Blog.Infrastructure.Data
{
    public abstract class BaseModel
    {
        //some comment
        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}

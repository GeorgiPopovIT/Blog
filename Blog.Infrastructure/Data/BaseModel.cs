using System.ComponentModel.DataAnnotations;

namespace Blog.Infrastructure.Data
{
    public abstract class BaseModel<T>
    {
        //some comment
        [Key]
        public T? Id { get; set; }

        public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedOn { get; set; }
    }
}

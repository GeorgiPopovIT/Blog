using System.ComponentModel.DataAnnotations;

namespace Blog.Core.Models.Comments
{
	public record CommentInputModel([Required]
	[MinLength(1,ErrorMessage ="Comment have to be at least 1 character.")]
	string Content,
		string UserId,int PostId);
	//public class CommentInputModel
	//{
	//	public string Content { get; init; }

	//	public string UserId { get; init; }
	//}
}

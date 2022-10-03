using Blog.Core.Contracts;
using Blog.Core.Models.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateComment(CommentInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
               
            }

            await commentService.CreateComment(inputModel);
        }

    }
}

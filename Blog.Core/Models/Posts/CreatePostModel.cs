using Blog.Core.CustomValidation;
using Blog.Core.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Blog.Core.Models.Posts
{
    public class CreatePostModel
    {
        [Required(ErrorMessage = ModelsConstants.ModelRequireErrorMessage)]
        [MinLength(ModelsConstants.PostTitleMinLength, ErrorMessage = ModelsConstants.PostTitleErrorMessageForMinLength)]
        public string? Title { get; set; }

        [Required(ErrorMessage = ModelsConstants.ModelRequireErrorMessage)]
        [MinLength(ModelsConstants.PostContentMinLength, ErrorMessage = ModelsConstants.PostTitleErrorMessageForMinLength)]
        public string? Content { get; set; }

        [AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg" })]
        public IFormFile? PhotoPost { get; set; }
    }
}

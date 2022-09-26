using Blog.Core.CustomValidation;
using Blog.Core.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Blog.Core.Models.Posts
{
    public class CreatePostModel
    {
        [Required(ErrorMessage = Constants.ModelRequireErrorMessage)]
        [MinLength(Constants.PostTitleMinLength, ErrorMessage = Constants.PostTitleErrorMessageForMinLength)]
        public string? Title { get; set; }

        [Required(ErrorMessage = Constants.ModelRequireErrorMessage)]
        [MinLength(Constants.PostContentMinLength, ErrorMessage = Constants.PostTitleErrorMessageForMinLength)]
        public string? Content { get; set; }

        [AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg" })]
        [Display(Name ="Image input (optional)")]
        public IFormFile? PhotoPost { get; set; }
    }
}


namespace Blog.Core.Common
{
    internal class ModelsConstants
    {
        public const string ModelRequireErrorMessage = "The field is empty.";

        public const int PostTitleMinLength = 1;
        public const string PostTitleErrorMessageForMinLength = "Title must be at least {1} characters long.";
        public const int PostContentMinLength = 5;
        public const string PostPhotoExtensionErrorMessage = "This photo extension is not allowed!";

    }
}

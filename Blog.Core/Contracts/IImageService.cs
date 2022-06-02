using Microsoft.AspNetCore.Http;

namespace Blog.Core.Contracts
{
    public interface IImageService
    {
        public void Process(string directoryPath, string physicalPath, IFormFile currFile);
    }
}

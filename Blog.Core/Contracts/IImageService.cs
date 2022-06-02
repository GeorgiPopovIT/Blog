using Microsoft.AspNetCore.Http;

namespace Blog.Core.Contracts
{
    public interface IImageService
    {
        public Task Process(string directoryPath, string physicalPath, IFormFile currFile);
    }
}

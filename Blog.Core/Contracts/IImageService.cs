using Microsoft.AspNetCore.Http;

namespace Blog.Core.Contracts
{
    public interface IImageService
    {
        Task Process(string directoryPath, string physicalPath, IFormFile currFile);
    }
}

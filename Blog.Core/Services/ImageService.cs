using Blog.Core.Contracts;
using Microsoft.AspNetCore.Http;

namespace Blog.Core.Services
{
    public class ImageService : IImageService
    {
        public async Task Process(string directoryPath, string physicalPath, IFormFile currFile)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (FileStream stream = new FileStream(physicalPath, FileMode.OpenOrCreate))
            await currFile.CopyToAsync(stream);

        }
    }
}

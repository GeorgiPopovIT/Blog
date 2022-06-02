﻿using Blog.Core.Contracts;
using Microsoft.AspNetCore.Http;

namespace Blog.Core.Services
{
    public class ImageService : IImageService
    {
        public void Process(string directoryPath,string physicalPath,IFormFile currFile)
        {
            //var path = Path.Combine(directoryPath,)
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            var fileName = currFile.FileName;

            using (FileStream stream = new FileStream(physicalPath, FileMode.OpenOrCreate))
            {
                 currFile.CopyTo(stream);
            }
        }
    }
}
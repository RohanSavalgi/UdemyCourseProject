using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortalWebAPI.Repositories
{
    public class uploadImageRepository : IUploadRepo
    {
        public async Task<string> Upload(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory() + @"Resources\Images" + fileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return getServerRelativePath(fileName);

        }

        public string getServerRelativePath(string fileName)
        {
            return Path.Combine(@"Resources\Images", fileName);
        }
    }
}

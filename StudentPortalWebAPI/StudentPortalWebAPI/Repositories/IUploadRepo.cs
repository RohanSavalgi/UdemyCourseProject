using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortalWebAPI.Repositories
{
    public interface IUploadRepo
    {
        public Task<string> Upload(IFormFile file, string fileName);
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction
{
    public interface IFileUpload
    {
        Task<string> UploadPicAsync(IFormFile file);
    }
}

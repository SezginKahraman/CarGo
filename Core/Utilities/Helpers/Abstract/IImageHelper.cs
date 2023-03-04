using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.Abstract
{
    public interface IImageHelper
    {
        IResult UploadImage(IFormFile file, string rootPath, out string fullPath);
        void DeleteImage(IFormFile file, string fullPath);
        void UpdateImage(IFormFile file, string rootPath, out string fullPath);
    }
}

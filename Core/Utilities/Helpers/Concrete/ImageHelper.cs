using Core.Utilities.Helpers.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.Concrete
{
    public class ImageHelper : IImageHelper
    {
        public IResult UploadImage(IFormFile file, string rootPath, out string fullPath)
        {
            if (file.Length == 0 || file == null)
            {
                fullPath = null;
                return new ErrorResult("no image has added.");
            }
            var extension = Path.GetExtension(file.FileName).Trim('.').ToLower();

            if (!new[] { "png", "jpeg", "jpg" }.Contains(extension))
            {
                fullPath = null;
                return new ErrorResult("extension is wrong !");
            }
            //If there is no directory in this root path
            if (!Directory.Exists(Path.Combine(rootPath)))
            {
                //Create a directory
                Directory.CreateDirectory(rootPath);
            }
            //Note that rootPath does'not contain file name. It is the path without the file name.
            if(file.Length>0 && file != null)
            {
                //Create unique filePath
                fullPath = rootPath +"\\"+ file.FileName ;
                using (Stream stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Flush(); //Flush garbages
                }
            }
            fullPath = rootPath + "\\" + file.FileName;
            return new SuccessResult("image has been added successfully");

        }
        public void DeleteImage(IFormFile file, string rootPath)
        {
            var fullPath = rootPath + "\\" + file.FileName;
            if(File.Exists(fullPath)){
                File.Delete(fullPath);
            }
        }

        public void UpdateImage(IFormFile file, string rootPath, out string fullPath)
        {
            var deletePath = rootPath + "\\" + file.FileName;
            if (File.Exists(deletePath))
            {
                File.Delete(deletePath);
            }
            UploadImage(file, rootPath, out fullPath);
        }
    }
}

using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : ControllerBase
    {
        ICarImageService _carImageService;
        IWebHostEnvironment _env;
        public CarImageController(ICarImageService carImageService, IWebHostEnvironment env)
        {
            _carImageService = carImageService;
            _env = env;
        }
    
        [HttpPost]
        [Route("addimage")]
        public IActionResult AddImage([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage image)
        {
            var rootPath = GetPath();
            _carImageService.Add(file, rootPath, image);
            return Ok("Resim eklendi");
        }

        private string GetPath()
        {
            var path = _env.WebRootPath + "\\CarImages\\";
            return path;

        }
    }
}

using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file, string rootPath, CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Update(CarImage carImage);
        IDataResult<CarImage> GetImageByImageId(int id);
        IDataResult<List<CarImage>> GetAllImagesByCarId(int id);
        IDataResult<List<CarImage>> GetAllImages();
     
    }
}

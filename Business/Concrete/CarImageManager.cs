using Business.Abstract;
using Core.Utilities.Helpers.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IImageHelper _imageIOHelper;
        public CarImageManager(ICarImageDal carImage, IImageHelper imageHelper)
        {
            _carImageDal = carImage;
            _imageIOHelper = imageHelper;
        }
        public IResult Add(IFormFile file, string rootPath, CarImage carImage)
        {
            string fullPath;

            //First upload the image to the system.
            _imageIOHelper.UpdateImage(file, rootPath, out fullPath);

            carImage.ImagePath = fullPath;

            carImage.Date = DateTime.UtcNow;

            //Add the image path' to the database in order to use it in view part by its path.
            _carImageDal.Add(carImage);

            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAllImages()
        {

            var result = _carImageDal.GetAll();

            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IDataResult<List<CarImage>> GetAllImagesByCarId(int id)
        {
            var result = _carImageDal.GetAll(x=>x.CarId == id);

            if(result == null)
            {
                result = new List<CarImage>() { new CarImage { CarId = id , 
                    ImagePath = _carImageDal.Get(x=>x.CarId == null).ImagePath} };
            }

            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IDataResult<CarImage> GetImageByImageId(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(x => x.Id == id));
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
    }
}

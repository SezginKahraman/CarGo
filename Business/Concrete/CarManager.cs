using Business.Abstract;
using Business.Validations.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            //ValidationTool.Validate(CarValidator, Car);
            CarValidator carValidator = new CarValidator();
            var validationresult = carValidator.Validate(car);
            if (validationresult.IsValid)
            {
                _carDal.Add(car);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            var result = _carDal.GetAll();
            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<Car>> GetByBrandId(int id)
        {
            var result = _carDal.GetAll(x=>x.BrandId == id);
            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<Car>> GetByColorId(int id)
        {
            var result = _carDal.GetAll(x => x.ColorId == id);
            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<Car> GetById(int id)
        {
            var result = _carDal.Get(x => x.Id == id);
            return new SuccessDataResult<Car>(result);
        }

        public IDataResult<List<Car>> GetByMinAndMaxPrice(decimal minPrice, decimal maxPrice)
        {
            var result = _carDal.GetAll(x => x.UnitPrice>minPrice && x.UnitPrice<maxPrice);
            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<CarDetailDto>> GetAllCarsDetails()
        {
            var result = _carDal.GetAllCarsDetail();
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
    }
}

using Business.Abstract;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Color color)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Color>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ColorDetailDto>> GetAllCarsDetails()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Color>> GetByBrandId(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Color>> GetByColorId(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Color> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Color>> GetByMinAndMaxPrice(decimal minPrice, decimal maxPrice)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Color color)
        {
            throw new NotImplementedException();
        }
    }
}

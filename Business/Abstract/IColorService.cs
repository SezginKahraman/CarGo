using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        //CRUD OPERATİONS   
        IResult Add(Color color);
        IResult Delete(Color color);
        IResult Update(Color color);
        IDataResult<Color> GetById(int id);
        IDataResult<List<Color>> GetAll();
        IDataResult<List<Color>> GetByBrandId(int id);
        IDataResult<List<Color>> GetByColorId(int id);
        IDataResult<List<Color>> GetByMinAndMaxPrice(decimal minPrice, decimal maxPrice);
        IDataResult<List<ColorDetailDto>> GetAllCarsDetails();
    }
}

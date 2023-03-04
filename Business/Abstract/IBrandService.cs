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
    public interface IBrandService
    {
        //CRUD OPERATİONS   
        IResult Add(Brand brand);
        IResult Delete(Brand brand);
        IResult Update(Brand brand);
        IDataResult<Brand> GetBrandByBrandId(int id);
        IDataResult<List<Brand>> GetAllBrands();
        IDataResult<List<BrandDetailDto>> GetAllCarsDetails();
    }
}

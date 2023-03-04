using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        //CRUD OPERATİONS   
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        Car Get(Expression<Func<Car, bool>> filter);
        List<Car> GetAll(Expression<Func<Car,bool>> filter=null);
        List<CarDetailDto> GetAllCarsDetail(Expression<Func<CarDetailDto, bool>> filter = null);
    }
}

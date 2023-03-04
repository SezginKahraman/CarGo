using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        //First, we need the database context in order to access the Car table in the database.
        //If we make an instance of the CarGoContext, we can access the DbSet properties of the table.
        public void Add(Car car)
        {
            using (CarGoContext carGoContext = new CarGoContext())
            {
                //first find the entity in the database context. 
                var addedCar = carGoContext.Entry(car);
                addedCar.State = EntityState.Added;
                carGoContext.SaveChanges();
            }
        }

        public void Delete(Car car)
        {
            using (CarGoContext carGoContext = new CarGoContext())
            {
                //first find the entity in the database context. 
                var addedCar = carGoContext.Entry(car);
                addedCar.State = EntityState.Deleted;
                carGoContext.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            using (CarGoContext carGoContext = new CarGoContext())
            {
                return carGoContext.Set<Car>().SingleOrDefault(filter);
            }

        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarGoContext carGoContext = new CarGoContext())
            {
                return filter == null ? carGoContext.Set<Car>().ToList() : carGoContext.Set<Car>().Where(filter).ToList();

            }
        }

        public List<CarDetailDto> GetAllCarsDetail(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            //Disposible pattern
            using (CarGoContext carGoContext= new CarGoContext())
            {
                var result = from cartable in carGoContext.Cars
                             join brandtable in carGoContext.Brands on
                             cartable.BrandId equals brandtable.Id
                             join colortable in carGoContext.Colors on
                             cartable.ColorId equals colortable.Id
                             select new CarDetailDto
                             {
                                 ColorId = colortable.Id,
                                 BrandName = brandtable.BrandName,
                                 BrandId = brandtable.Id,
                                 ColorName = colortable.ColorName,
                                 DailyPrice = cartable.DailyPrice,
                                 Description = cartable.Description,
                                 Id = cartable.Id,
                                 ModelYear = cartable.ModelYear,
                                 Name = cartable.Name,
                                 UnitPrice = cartable.UnitPrice
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public void Update(Car car)
        {
            using (CarGoContext carGoContext = new CarGoContext())
            {
                //first find the entity in the database context. 
                var addedCar = carGoContext.Entry(car);
                addedCar.State = EntityState.Modified;
                carGoContext.SaveChanges();
            }
        }
    }
}

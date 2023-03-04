using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            //It represents the data which will come from the database as the test cars.

            _cars = new List<Car> { 
                new Car { BrandId = 1, ColorId=5, Description = "son model", Id = 1, ModelYear= DateTime.Parse("2019"), UnitPrice = 1900000},
                new Car { BrandId = 1, ColorId=5, Description = "son model", Id = 1, ModelYear= DateTime.Parse("2019"), UnitPrice = 1900000 },
                new Car { BrandId = 1, ColorId=5, Description = "son model", Id = 1, ModelYear= DateTime.Parse("2019"), UnitPrice = 1900000},
                new Car {  BrandId = 1, ColorId=5, Description = "son model", Id = 1, ModelYear= DateTime.Parse("2019"), UnitPrice = 1900000},
                new Car { BrandId = 1, ColorId=5, Description = "son model", Id = 1, ModelYear= DateTime.Parse("2019"), UnitPrice = 1900000},
                new Car { BrandId = 1, ColorId=5, Description = "son model", Id = 1, ModelYear= DateTime.Parse("2019"), UnitPrice = 1900000},
                new Car { BrandId = 1, ColorId=5, Description = "son model", Id = 1, ModelYear= DateTime.Parse("2019"), UnitPrice = 1900000},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            //We can not direktly Remove the parameter Car from the _cars. The Reason for that, the Car class has
            //Primitive value type, which means it is hold by its reference in the heap.
            //In order to find the Car which we want to delete, we need to access its reference.
            //By using FirstOrDefault, we can access the reference of that Car. So deletedCar variable represent the reference of that deleted car in the List<Car>.
            Car deletedCar = _cars.FirstOrDefault(x=>x.Id==car.Id);
            _cars.Remove(deletedCar);
        }

        //In the Get Method, the filter cannot be null ! Because, there is a lot of cars in this list, if a specific car wanted to be gotten, there has to be a filter for that car.
        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return _cars.FirstOrDefault(x=>x.ColorId == 1);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            //We can not directly give the filter inside of the Where cause of the List class.
            //The filter only can be given to the DbSet variants like => context.Set<Car>().Where(filter);

            return filter == null ? _cars : _cars.Where(x=>x.ColorId == 1).ToList();
        }

        public List<CarDetailDto> GetAllCarsDetail(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var updatedCar = _cars.FirstOrDefault(x => x.Id == car.Id);
            //The classes primitive type. So if we change the updatedCars' properties, the car in the list will be affected also.
            updatedCar.ColorId = car.ColorId;
            updatedCar.Description = car.Description;
            updatedCar.UnitPrice = car.UnitPrice;
            updatedCar.ModelYear = car.ModelYear;
        }
    }
}

using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;   
        }
        [Route("getcarbyid")]
        [HttpGet]
        public Car GetCarById(int id)
        {
            return _carService.GetById(id).Data;
        }
        [Route("getallcars")]
        [HttpGet]
        public List<Car> GetAllCars()
        {
            return _carService.GetAll().Data;
        }
        [Route("addcar")]
        [HttpPost]
        public IResult AddCar(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return (IResult)Ok(result.Message);
            }
            return (IResult)BadRequest(result.Message);
        }
    }
}

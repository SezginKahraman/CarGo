using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
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
        [Route("getallcarsdetails")]
        [HttpGet]
        public List<CarDetailDto> GetAllCarsDetails()
        {
            return _carService.GetAllCarsDetails().Data;
        }


        [Route("addcar")]
        [HttpPost]
        public IActionResult AddCar(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}

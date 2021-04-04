using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Business.Abstract;
using Entities.Concrete;

namespace MvcWebUI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private ICarService _carService;
        
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: api/car/getall
        [HttpGet("getall")]
        public IEnumerable<Car> Get()
        {
            var cars = _carService.GetAll();
            return cars;
        }
        [HttpGet("getbycompany/{companyId}")]
        public IEnumerable<Car> GetByCompany(int companyId)
        {
            var cars = _carService.GetByCompany(companyId);
            return cars;
        }
        [HttpGet("getbyavailable")]
        public IEnumerable<Car> GetByAvailable()
        {
            var cars = _carService.GetByAvailable();
            return cars;
        }

        [HttpPost("add")]
        [ValidateAntiForgeryToken]
        public IActionResult Add([FromBody] Car car)
        {
            _carService.Add(car);
            return Ok(car);
        }

    }
}

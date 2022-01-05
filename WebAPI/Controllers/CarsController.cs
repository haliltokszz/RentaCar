using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _carService.Get(id);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageFilter pageFilter, [FromBody] CarFilter filter)
        {
            var result = await _carService.GetAll(pageFilter, filter);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbyavailable")]
        public async Task<IActionResult> GetByAvailable()
        {
            var result = await _carService.GetByAvailable();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Car car)
        {
            var result = await _carService.Add(car);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Car car)
        {
            var result = await _carService.Update(car);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Car car)
        {
            var result = await _carService.Delete(car);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
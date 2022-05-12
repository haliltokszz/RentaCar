using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : Controller
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _rentalService.Get(id);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageFilter pageFilter, [FromQuery] RentalFilter filter)
        {
            var result = await _rentalService.GetAll(pageFilter, filter);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
        
        [HttpGet("getcarsbyavailable")]
        public async Task<IActionResult> GetCarsByAvailable([FromQuery] RentalFilter filter)
        {
            var result = await _rentalService.GetCarsByAvailable(filter);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbynoapprove")]
        public async Task<IActionResult> GetByNoApprove()
        {
            var result = await _rentalService.GetByNoApprove();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([FromBody] Rental rental)
        {
            var result = await _rentalService.Add(rental);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
        [HttpPost("delivered")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delivered([FromBody] Rental rental)
        {
            var result = await _rentalService.Delivered(rental);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
        [HttpPost("approve")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve([FromBody] Rental rental)
        {
            var result = await _rentalService.Approve(rental);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Rental rental)
        {
            var result = await _rentalService.Update(rental);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Rental rental)
        {
            var result = await _rentalService.Delete(rental);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
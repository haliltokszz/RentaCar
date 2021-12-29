using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //[Authorize]
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
        public async Task<IActionResult> GetAll()
        {
            var result = await _rentalService.GetAll();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbycompany/{companyId}")]
        public async Task<IActionResult> GetByCompany(string companyId)
        {
            var result = await _rentalService.GetByCompany(companyId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbycustomer/{customerId}")]
        public async Task<IActionResult> GetByCustomer(string customerId)
        {
            var result = await _rentalService.GetByCustomer(customerId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbycar/{carId}")]
        public async Task<IActionResult> GetByCar(string carId)
        {
            var result = await _rentalService.GetByCar(carId);
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
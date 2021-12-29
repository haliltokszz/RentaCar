using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _customerService.Get(id);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerService.GetAll();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Customer customer)
        {
            var result = await _customerService.Add(customer);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Customer customer)
        {
            var result = await _customerService.Update(customer);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Customer customer)
        {
            var result = await _customerService.Delete(customer);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
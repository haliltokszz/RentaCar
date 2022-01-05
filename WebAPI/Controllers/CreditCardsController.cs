using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : Controller
    {
        private readonly ICreditCardService _creditCardService;

        public CreditCardsController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }


        [HttpGet("getallbycustomerid")]
        public async Task<IActionResult> GetAllByCustomerId(string customerId)
        {
            var result = await _creditCardService.GetAllByCustomerId(customerId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CreditCard creditCard)
        {
            var result = await _creditCardService.Add(creditCard);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(CreditCard creditCard)
        {
            var result = await _creditCardService.Delete(creditCard);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
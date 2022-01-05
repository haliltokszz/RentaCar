using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindeksController : Controller
    {
        private readonly IFindeksService _findeksService;

        public FindeksController(IFindeksService findeksService)
        {
            _findeksService = findeksService;
        }

        [HttpGet("getbycustomerid")]
        public async Task<IActionResult> GetByCustomerId(string customerId)
        {
            var result = await _findeksService.GetByCustomer(customerId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
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
    public class BrandsController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _brandService.Get(id);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] BrandAndColorFilter filter= null)
        {
            var result = await _brandService.GetAll(filter);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Brand brand)
        {
            var result = await _brandService.Add(brand);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Brand brand)
        {
            var result = await _brandService.Update(brand);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("/delete")]
        public async Task<IActionResult> Delete(Brand brand)
        {
            var result = await _brandService.Delete(brand);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
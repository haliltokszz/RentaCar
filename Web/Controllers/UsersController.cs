using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entities.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _userService.Get(id);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserDetailDto user)
        {
            var result = await _userService.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(UserDetailDto user)
        {
            var result = await _userService.Update(user);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(UserDetailDto user)
        {
            var result = await _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

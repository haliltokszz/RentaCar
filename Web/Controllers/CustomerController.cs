using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Security.Hashing;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Business.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private IAuthService _authService;
        private ICustomerService _customerService;
        public CustomerController(IAuthService authService, ICustomerService userService)
        {
            _authService = authService;
            _customerService = userService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var customers = _customerService.GetAll();
            //Hidden password for security
            foreach (Customer customer in customers)
            {
                customer.PasswordHash = null;
            }
            return Ok(customers);
        }

        [AllowAnonymous]
        [HttpPost("login" )]
        public IActionResult Login([FromBody] UserForLoginDto userForLoginDto)
        {
            var resultUser = _authService.Login(userForLoginDto, "Customer");
            
            if (resultUser == null)
                return Unauthorized();
            return Ok(resultUser);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserForRegisterDto userForRegister)
        {
            if(_authService.UserExist(userForRegister.UserName, "Customer") )
                ModelState.AddModelError("UserName","Username already exist");
            if (!ModelState.IsValid) return BadRequest(modelState: ModelState);
            Customer user = new Customer
            {
                Email = userForRegister.Email,
                Name = userForRegister.Name,
                Surname = userForRegister.Surname,
                Address = userForRegister.Address,
                BirthDate = userForRegister.BirthDate,
                PhoneNumber = userForRegister.PhoneNumber,
                TCno = userForRegister.TCno,
                UserName = userForRegister.UserName
            };
            user = (Customer)_authService.CreatePasswordHash(user, userForRegister.Password);
            _customerService.Add(user);
            return StatusCode(201);
        }
    }
}

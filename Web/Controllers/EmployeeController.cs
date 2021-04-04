using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController:ControllerBase
    {
        private IAuthService _authService;
        private IEmployeeService _employeeService;
        public EmployeeController(IAuthService authService, IEmployeeService employeeService)
        {
            _authService = authService;
            _employeeService = employeeService;
        }

        [HttpGet]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var employees = _employeeService.GetAll();
            //Hidden password for security
            foreach (Employee employee in employees)
            {
                employee.PasswordHash = null;
            }
            return Ok(employees);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] UserForLoginDto users)
        {
            var resultUser = _authService.Login(users,"Employee");

            if (resultUser == null)
                return Unauthorized();
            return Ok(resultUser);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] EmployeeForRegisterDto employeesForRegister)
        {
            if (_authService.UserExist(employeesForRegister.UserName, "Customer"))
                ModelState.AddModelError("UserName", "Username already exist");
            if (!ModelState.IsValid) return BadRequest(modelState: ModelState);
            Employee user = new Employee()
            {
                Email = employeesForRegister.Email,
                Name = employeesForRegister.Name,
                Surname = employeesForRegister.Surname,
                Address = employeesForRegister.Address,
                BirthDate = employeesForRegister.BirthDate,
                PhoneNumber = employeesForRegister.PhoneNumber,
                TCno = employeesForRegister.TCno,
                UserName = employeesForRegister.UserName,
                CompanyId = employeesForRegister.CompanyId
            };
            user = (Employee)_authService.CreatePasswordHash(user, employeesForRegister.Password);
            _employeeService.Add(user);
            return StatusCode(201);
        }
    }
}

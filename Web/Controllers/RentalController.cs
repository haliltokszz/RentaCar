using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Business.Abstract;
using Entities.Concrete;

namespace Web.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : Controller
    {
        private IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        // GET: api/car/getall
        [HttpGet("getall")]
        public IEnumerable<Rental> Get()
        {
            var rentals = _rentalService.GetAll();
            return rentals;
        }
        [HttpGet("getbycompany/{companyId}")]
        public IEnumerable<Rental> GetByCompany(int companyId)
        {
            var rentals = _rentalService.GetByCompany(companyId);
            return rentals;
        }
        [HttpGet("getbycustomer/{customerId}")]
        public IEnumerable<Rental> GetByCustomer(int customerId)
        {
            var rentals = _rentalService.GetByCustomer(customerId);
            return rentals;
        }
        [HttpGet("getbycar/{carId}")]
        public IEnumerable<Rental> GetByCar(int carId)
        {
            var rentals = _rentalService.GetByCar(carId);
            return rentals;
        }
        [HttpGet("getbynoapprove")]
        public IEnumerable<Rental> GetByNoApprove()
        {
            var rentals = _rentalService.GetByNoApprove();
            return rentals;
        }

        [HttpPost("add")]
        [ValidateAntiForgeryToken]
        public IActionResult Add([FromBody] Rental rentals)
        {
            _rentalService.Add(rentals);
            return Ok(rentals);
        }
    }
}

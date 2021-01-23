using RentaCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentaCar.Business.Abstract
{
    public interface IRentalService
    {
        List<Rentals> GetAll();
        List<Rentals> GetByCustomer(int customerId);
        List<Rentals> GetByCar(int carId);
        void Add(Rentals rental);
        void Update(Rentals rental);
        void Delete(Rentals rental);
    }
}

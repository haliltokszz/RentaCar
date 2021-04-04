using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        List<Rental> GetAll();
        List<Rental> GetByCustomer(int customerId);
        List<Rental> GetByCompany(int companyId);
        List<Rental> GetByNoApprove();
        List<Rental> GetByCar(int carId);
        void Add(Rental rental);
        void Update(Rental rental);
        void Delete(Rental rental);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private UnitofWork _unitofWork;

        public RentalManager()
        {
            _unitofWork = new UnitofWork();
        }
        public void Add(Rental rental)
        {
            _unitofWork.Rentals.Add(rental);
        }

        public void Delete(Rental rental)
        {
            _unitofWork.Rentals.Delete(rental);
        }
        public List<Rental> GetAll()
        {
            return _unitofWork.Rentals.GetList();
        }

        public List<Rental> GetByCar(int carId)
        {
            return _unitofWork.Rentals.GetList(rental=>rental.CarId == carId);
        }

        public List<Rental> GetByCompany(int companyId)
        {
            return _unitofWork.Rentals.GetList(rental => rental.CompanyId == companyId);
        }

        public List<Rental> GetByCustomer(int customerId)
        {
            return _unitofWork.Rentals.GetList(rental => rental.CustomerId == customerId);
        }

        public List<Rental> GetByNoApprove()
        {
            return _unitofWork.Rentals.GetList(rental => rental.Approve == false);
        }

        public void Update(Rental rental)
        {
            _unitofWork.Rentals.Update(rental);
        }
    }
}

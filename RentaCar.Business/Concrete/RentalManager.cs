using System;
using System.Collections.Generic;
using System.Text;
using RentaCar.Business.Abstract;
using RentaCar.DataAccess.Concrete;
using RentaCar.Entities.Concrete;

namespace RentaCar.Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private UnitofWork _unitofWork;

        public RentalManager()
        {
            _unitofWork = new UnitofWork();
        }
        public void Add(Rentals rental)
        {
            _unitofWork.Rentals.Add(rental);
        }

        public void Delete(Rentals rental)
        {
            _unitofWork.Rentals.Delete(rental);
        }

        public List<Rentals> GetAll()
        {
            return _unitofWork.Rentals.GetList();
        }

        public List<Rentals> GetByCar(int carId)
        {
            return _unitofWork.Rentals.GetList(rental=>rental.CarId == carId);
        }

        public List<Rentals> GetByCompany(int companyId)
        {
            return _unitofWork.Rentals.GetList(rental => rental.CompanyId == companyId);
        }

        public List<Rentals> GetByCustomer(int customerId)
        {
            return _unitofWork.Rentals.GetList(rental => rental.CustomerId == customerId);
        }

        public List<Rentals> GetByNoApprove()
        {
            return _unitofWork.Rentals.GetList(rental => rental.Approve == false);
        }

        public void Update(Rentals rental)
        {
            _unitofWork.Rentals.Update(rental);
        }
    }
}

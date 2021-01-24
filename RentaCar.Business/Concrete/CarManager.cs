using System;
using System.Collections.Generic;
using System.Text;
using RentaCar.Business.Abstract;
using RentaCar.DataAccess.Abstract;
using RentaCar.DataAccess.Concrete;
using RentaCar.Entities.Concrete;

namespace RentaCar.Business.Concrete
{
    public class CarManager : ICarService
    {
        private IUnitofWork _unitofWork;

        public CarManager(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public void Add(Cars car)
        {
            _unitofWork.Cars.Add(car);
        }

        public void Delete(Cars car)
        {
            _unitofWork.Cars.Delete(car);
        }

        public List<Cars> GetAll()
        {
            return _unitofWork.Cars.GetList();
        }

        public List<Cars> GetByAvailable()
        {
            return _unitofWork.Cars.GetList(car => car.Available == true);
        }

        public List<Cars> GetByCompany(int companyId)
        {
            return _unitofWork.Cars.GetList(car=>car.CompanyId == companyId);
        }

        public void Update(Cars car)
        {
            _unitofWork.Cars.Update(car);
        }
    }
}

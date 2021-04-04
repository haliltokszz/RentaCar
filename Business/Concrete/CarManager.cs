using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private UnitofWork _unitofWork;

        public CarManager()
        {
            _unitofWork = new UnitofWork();
        }

        public void GetCarCompany(Car car)
        { 
            var company = _unitofWork.Companies.Get(c => c.Id == car.CompanyId);
            car.Company = company;
            company.Cars.Add(car); //This car is adding to Company's Cars List
        }

        public void GetCarsCompany(List<Car> cars)
        {
            foreach (var car in cars)
            { 
                GetCarCompany(car);
            }
        }
        public void Add(Car car)
        {
            _unitofWork.Cars.Add(car);
        }

        public void Delete(Car car)
        {
            _unitofWork.Cars.Delete(car);
        }

        public Car GetCar(int carId)
        {
            var car = _unitofWork.Cars.Get(c=>c.Id == carId);
            GetCarCompany(car);
            return car;
        }

        public List<Car> GetAll()
        {
            var cars = _unitofWork.Cars.GetList();
            GetCarsCompany(cars);
            return cars;
        }

        public List<Car> GetByAvailable()
        {
            var cars= _unitofWork.Cars.GetList(car => car.Available == true);
            GetCarsCompany(cars);
            return cars;
        }

        public List<Car> GetByCompany(int companyId)
        {
            var cars= _unitofWork.Cars.GetList(car=>car.CompanyId == companyId);
            GetCarsCompany(cars);
            return cars;
        }

        public void Update(Car car)
        {
            _unitofWork.Cars.Update(car);
        }
    }
}

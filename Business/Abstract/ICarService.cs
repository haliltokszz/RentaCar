using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetByCompany(int companyId);
        List<Car> GetByAvailable();
        Car GetCar(int carId);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

        void GetCarsCompany(List<Car> cars);
        void GetCarCompany(Car car);
    }
}

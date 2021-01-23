using RentaCar.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentaCar.Business.Abstract
{
    public interface IUserService
    {
        List<Users> GetAll();
        void Add(Users user);
        void Update(Users user);
        void Delete(Users user);
    }
}

using System;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class CarImage : AuditableEntity
    {
        public string ImagePath { get; set; } // for aws cloud
        public string ImageBase64 { get; set; }

        public DateTime Date { get; set; }

        //References
        public string CarId { get; set; }
        public Car Car { get; set; }
    }
}
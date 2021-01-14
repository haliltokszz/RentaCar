using System;
using System.Collections.Generic;
using System.Text;

namespace Rent_a_Car.Entities.Concrete
{
    public class Rental
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int KMDelivery { get; set; }
        public int KMCurrent { get; set; }
        public int Price { get; set; }
    }
}

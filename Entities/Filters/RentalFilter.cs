using System;

namespace Entities.Filters
{
    public class RentalFilter: IFilter
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public bool Approve { get; set; }
        public bool Delivered { get; set; }

        public string CustomerId { get; set; }
        public string CarId { get; set; }
        public string CompanyId { get; set; }
    }
}
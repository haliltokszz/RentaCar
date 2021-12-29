using System;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Rental : AuditableEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int KmDelivery { get; set; }
        public int KmCurrent { get; set; }
        public decimal Price { get; set; }
        public DateTime ApprovalDate { get; set; }
        public bool Approve { get; set; }
        public bool Delivered { get; set; }
        public DateTime DeliveredDate { get; set; }

        //References
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string CarId { get; set; }
        public Car Car { get; set; }
        public string CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
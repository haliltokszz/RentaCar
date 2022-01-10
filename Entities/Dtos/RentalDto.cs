using System;
using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.Dtos
{
    public class RentalDto: IDto
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
        public string CustomerId { get; set; }
        public string CarId { get; set; }
        public string CompanyId { get; set; }
    }
}
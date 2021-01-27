using RentaCar.Core.Entities;
using RentaCar.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentaCar.Entities.Concrete
{
    public class Rentals : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customers Customer { get; set; }
        public int CarId { get; set; }
        public Cars Car { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int KMDelivery { get; set; }
        public int KMCurrent { get; set; }
        public decimal Price { get; set; }
        public int CompanyId { get; set; }
        public Companies Company { get; set; }
        public int EmployeeId { get; set; }
        public Employees Employee { get; set; }
        public DateTime ApprovalDate { get; set; }
        public bool Approve { get; set; }
        public bool Delivered { get; set; }
        public DateTime DeliveredDate { get; set; }
    }
}

using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class RentalCount: AuditableEntity
    {
        public CarCategories Category { get; set; }
        public int TotalRent { get; set; }
        public int Month { get; set; }
    }
}
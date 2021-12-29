using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Brand : AuditableEntity
    {
        public string Name { get; set; }
        public CarCategories Category { get; set; }
    }

    public enum CarCategories
    {
        Sedan,
        Hatchback,
        SUV,
        StationWagon,
        Coupe,
        Sports,
        Minivan,
        Pickup
    }
}
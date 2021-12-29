using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Customer : AuditableEntity
    {
        public int DriveExperience { get; set; }

        //References
        public string UserId { get; set; }
        public User User { get; set; }
        public string CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
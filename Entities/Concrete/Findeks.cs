using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Findeks : AuditableEntity
    {
        public string NationalIdentity { get; set; }
        public short Score { get; set; }
        
        //References
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
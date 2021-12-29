using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Payment: AuditableEntity
    {
        public string Number { get; set; }
        public string ExpireMonth { get; set; }
        public string ExpireYear { get; set; }
        public string Cvv { get; set; }
        public string Owner { get; set; }
    }
}
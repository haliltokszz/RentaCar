using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class CreditCard : AuditableEntity
    {
        public string NameSurname { get; set; }
        public string CardNumber { get; set; }
        public byte ExpMonth { get; set; }
        public byte ExpYear { get; set; }
        public string Cvc { get; set; }
        public string CardType { get; set; }
        
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
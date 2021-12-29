using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    public class OperationClaim : AuditableEntity
    {
        public string Name { get; set; }
    }
}
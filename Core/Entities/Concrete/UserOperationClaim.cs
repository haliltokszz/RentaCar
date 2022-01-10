using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim : AuditableEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string OperationClaimId { get; set; }
    }
}
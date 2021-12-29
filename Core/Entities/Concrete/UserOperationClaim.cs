using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim:AuditableEntity
    {
        public string UserId { get; set; }
        public string OperationClaimId { get; set; }

    }
}

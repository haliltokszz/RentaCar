using System;

namespace Core.Entities.Abstract
{
    public abstract class AuditableEntity : IEntity
    {
        public string Id { get; set; } = new Guid().ToString();
        public DateTime CreatedTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedTime { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime DeletedTime { get; set; }
    }
}
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Color : AuditableEntity
    {
        public string Name { get; set; }
    }
}
using System.Collections.Generic;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Company : AuditableEntity
    {
        public Company()
        {
            Cars = new List<Car>();
        }

        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public string FindeksId { get; set; }
        public Findeks Findeks { get; set; }
        public List<Car> Cars { get; set; }
    }
}
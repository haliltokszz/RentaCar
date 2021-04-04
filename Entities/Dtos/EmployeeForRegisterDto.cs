using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Entities.Dtos
{
    public class EmployeeForRegisterDto: UserForRegisterDto
    {
        public int CompanyId { get; set; }
    }
}
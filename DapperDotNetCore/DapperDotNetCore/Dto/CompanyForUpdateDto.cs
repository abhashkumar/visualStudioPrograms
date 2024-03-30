using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDotNetCore.Dto
{
    public class CompanyForUpdateDto
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
}

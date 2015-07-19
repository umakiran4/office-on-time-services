using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabAgeBusinessEntities
{
    public class EmployeeMasterBusinessEntity
    {

        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public long? EmployeeMobileNumber { get; set; }
    }
}

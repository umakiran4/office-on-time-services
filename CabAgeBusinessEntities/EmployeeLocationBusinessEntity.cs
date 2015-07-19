using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabAgeBusinessEntities
{
    public class EmployeeLocationBusinessEntity
    {
        public int EmployeeLocationID { get; set; }
        public int EmployeeID { get; set; }
        public System.Data.Entity.Spatial.DbGeography EmployeeGeoLocation { get; set; }

        public virtual EmployeeMasterBusinessEntity EmployeeMaster { get; set; }

    }
}

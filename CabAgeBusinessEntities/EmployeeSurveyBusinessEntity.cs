using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabAgeBusinessEntities
{
    public class EmployeeSurveyBusinessEntity
    {
 
        public int EmployeeID { get; set; }
        public int CategoryID { get; set; }
        public int Rating { get; set; }
        public virtual CategoryMasterBusinessEnitity CategoryMaster { get; set; }
        public virtual EmployeeMasterBusinessEntity EmployeeMaster { get; set; }

    }
}

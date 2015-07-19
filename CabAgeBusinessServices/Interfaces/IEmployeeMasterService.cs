using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabAgeBusinessEntities;

namespace CabAgeBusinessServices.Interfaces
{
    public interface IEmployeeMasterService
    {
        EmployeeMasterBusinessEntity GetEmployeeById(int id);

        IEnumerable<EmployeeMasterBusinessEntity> GetAllEmployees();

        void CreateEmployee(EmployeeMasterBusinessEntity newEmployee);

        bool IsEmployeeRegistered(int id);

    }
}

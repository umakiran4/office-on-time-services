﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabAgeBusinessEntities;

namespace CabAgeBusinessServices.Interfaces
{
    public interface IEmployeeMasterService
    {
        EmployeeMasterModel GetEmployeeById(int id);

        IEnumerable<EmployeeMasterModel> GetAllEmployees();

        void CreateEmployee(EmployeeMasterModel newEmployee);

        bool IsEmployeeRegistered(int id);

    }
}

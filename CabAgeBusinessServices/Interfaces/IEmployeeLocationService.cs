﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabAgeBusinessEntities;

namespace CabAgeBusinessServices.Interfaces
{
    public interface IEmployeeLocationService
    {
        
        EmployeeLocationModel GetLocationByEmployeeId(int id);

        void CreateEmployeeLocation(EmployeeLocationModel newEmployeeLocation);
    }
}

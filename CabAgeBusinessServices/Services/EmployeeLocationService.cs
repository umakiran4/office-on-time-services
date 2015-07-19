using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabAgeBusinessEntities;
using CabAgeDataModel.UnitOfWork;
using CabAgeDataModel;
using AutoMapper;
using System.Transactions;
using CabAgeBusinessServices.Interfaces;

namespace CabAgeBusinessServices.Services
{
    public class EmployeeLocationService : IEmployeeLocationService
    {
        private readonly UnitOfWork unitOfWork;

        public EmployeeLocationService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public EmployeeLocationBusinessEntity GetLocationByEmployeeId(int id)
        {
            var employeeLocation = unitOfWork.EmployeeLocationRepository.GetFirst(location => location.EmployeeID == id);

            if (employeeLocation == null) return null;

            Mapper.CreateMap<EmployeeLocation, EmployeeLocationBusinessEntity>();
            Mapper.CreateMap<EmployeeMaster, EmployeeMasterBusinessEntity>();
            var employeeLocationModel = Mapper.Map<EmployeeLocation,EmployeeLocationBusinessEntity>(employeeLocation);

            return employeeLocationModel;
        }


        public void CreateEmployeeLocation(EmployeeLocationBusinessEntity newEmployeeLocation)
        {

            using (var scope = new TransactionScope())
            {
                var employee = new EmployeeLocation
                {
                    EmployeeGeoLocation = newEmployeeLocation.EmployeeGeoLocation,
                    EmployeeLocationID = newEmployeeLocation.EmployeeLocationID,
                    EmployeeID = newEmployeeLocation.EmployeeID

                };
                unitOfWork.EmployeeLocationRepository.Insert(employee);
                unitOfWork.Save();
                scope.Complete();

            }
        }


    }
}

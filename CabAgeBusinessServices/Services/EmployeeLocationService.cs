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


        public EmployeeLocationModel GetLocationByEmployeeId(int id)
        {
            var employeeLocation = unitOfWork.EmployeeLocationRepository.GetFirst(location => location.ID == id);

            if (employeeLocation == null) return null;

            Mapper.CreateMap<EmployeeLocation, EmployeeLocationModel>();
            Mapper.CreateMap<EmployeeMaster, EmployeeMasterModel>();
            var employeeLocationModel = Mapper.Map<EmployeeLocation,EmployeeLocationModel>(employeeLocation);

            return employeeLocationModel;
        }


        public void CreateEmployeeLocation(EmployeeLocationModel newEmployeeLocation)
        {

            using (var scope = new TransactionScope())
            {
                var employee = new EmployeeLocation
                {
                    GeoLocation = newEmployeeLocation.GeoLocation,
                    LocationID = newEmployeeLocation.LocationID,
                    ID = newEmployeeLocation.ID

                };
                unitOfWork.EmployeeLocationRepository.Insert(employee);
                unitOfWork.Save();
                scope.Complete();

            }
        }


    }
}

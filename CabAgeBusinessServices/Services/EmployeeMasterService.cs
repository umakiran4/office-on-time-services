using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CabAgeBusinessEntities;
using CabAgeBusinessServices.Interfaces;
using CabAgeDataModel.UnitOfWork;
using AutoMapper;
using CabAgeDataModel;



namespace CabAgeBusinessServices.Services
{
    public class EmployeeMasterService : IEmployeeMasterService
    {
        private readonly UnitOfWork unitOfWork;

        public EmployeeMasterService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public EmployeeMasterBusinessEntity GetEmployeeById(int id)
        {
            var employee = unitOfWork.EmployeeMasterRepository.GetByID(id);
            

            if (employee == null) return null;

            Mapper.CreateMap<EmployeeMaster, EmployeeMasterBusinessEntity>();
            var employeeModel = Mapper.Map<EmployeeMaster, EmployeeMasterBusinessEntity>(employee);

            return employeeModel;
        }


        public IEnumerable<EmployeeMasterBusinessEntity> GetAllEmployees()  
        {
            var employees = unitOfWork.EmployeeMasterRepository.GetAll().ToList();

            if (!employees.Any()) return null;

            Mapper.CreateMap<EmployeeMaster, EmployeeMasterBusinessEntity>();
            var employeesModel = Mapper.Map<List<EmployeeMaster>, List<EmployeeMasterBusinessEntity>>(employees);

            return employeesModel;
        }

        public void CreateEmployee(EmployeeMasterBusinessEntity newEmployee)
        {

            using (var scope = new TransactionScope())
            {
                var employee = new EmployeeMaster
                {
                    EmployeeEmail = newEmployee.EmployeeEmail,
                    EmployeeID = newEmployee.EmployeeID,
                    EmployeeName = newEmployee.EmployeeName,
                    EmployeeMobileNumber = newEmployee.EmployeeMobileNumber,
                   
                };
                unitOfWork.EmployeeMasterRepository.Insert(employee);
                unitOfWork.Save();
                scope.Complete();

            }
        }

        public bool IsEmployeeRegistered(int id)
        {
            return unitOfWork.EmployeeMasterRepository.Exists(id);
        }

    }
}

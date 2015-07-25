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


        public EmployeeMasterModel GetEmployeeById(int id)
        {
            var employee = unitOfWork.EmployeeMasterRepository.GetByID(id);
            

            if (employee == null) return null;

            Mapper.CreateMap<EmployeeMaster, EmployeeMasterModel>();
            var employeeModel = Mapper.Map<EmployeeMaster, EmployeeMasterModel>(employee);

            return employeeModel;
        }


        public IEnumerable<EmployeeMasterModel> GetAllEmployees()  
        {
            var employees = unitOfWork.EmployeeMasterRepository.GetAll().ToList();

            if (!employees.Any()) return null;

            Mapper.CreateMap<EmployeeMaster, EmployeeMasterModel>();
            var employeesModel = Mapper.Map<List<EmployeeMaster>, List<EmployeeMasterModel>>(employees);

            return employeesModel;
        }

        public void CreateEmployee(EmployeeMasterModel newEmployee)
        {

            using (var scope = new TransactionScope())
            {
                var employee = new EmployeeMaster
                {
                    Email = newEmployee.Email,
                    ID = newEmployee.ID,
                    Name = newEmployee.Name,
                    Mobile = newEmployee.Mobile,
                   
                };
                unitOfWork.EmployeeMasterRepository.Insert(employee);
                unitOfWork.Save();
                scope.Complete();

            }
        }

        public void UpdateEmployee(EmployeeMasterModel existingEmployee)
        {

            using (var scope = new TransactionScope())
            {
                var employee = new EmployeeMaster
                {
                    Email = existingEmployee.Email,
                    ID = existingEmployee.ID,
                    Name = existingEmployee.Name,
                    Mobile = existingEmployee.Mobile,

                };
                unitOfWork.EmployeeMasterRepository.Update(employee);
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

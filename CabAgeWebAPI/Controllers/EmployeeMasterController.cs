using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CabAgeBusinessEntities;
using CabAgeBusinessServices.Interfaces;
using System.Data.Entity.Spatial;
using AttributeRouting.Web.Http;

namespace CabAgeWebAPI.Controllers
{
    public class EmployeeMasterController : ApiController
    {

        private readonly IEmployeeMasterService employeeMasterService;

        public EmployeeMasterController(IEmployeeMasterService employeeMasterService)
        {
            this.employeeMasterService = employeeMasterService;
        }

        [GET("employees/getall")]
        public HttpResponseMessage GetAllEmployees()
        {
            var employees = employeeMasterService.GetAllEmployees();
            if (employees == null || !employees.Any()) return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employees not found");
            var employeeEntities = employees as List<EmployeeMasterBusinessEntity> ?? employees.ToList();
            if (employeeEntities.Any())
                return Request.CreateResponse(HttpStatusCode.OK, employeeEntities);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employees not found");
        }

        [GET("employees/employee/{id?}")]
        public HttpResponseMessage GetEmployeeById(int id)
        {
            var employee= employeeMasterService.GetEmployeeById(id);
            if (employee == null) return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee not found");
            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }

        [POST("employee/create")]
        public void Post([FromBody] EmployeeMasterBusinessEntity employeeMasterBusinessEntity)
        {
            employeeMasterService.CreateEmployee(employeeMasterBusinessEntity);
        }


        [AcceptVerbs("GET")]
        [GET("employee/isregistered/{id?}")]
        public HttpResponseMessage IsEmployeeRegistered(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, employeeMasterService.IsEmployeeRegistered(id));
        }

    }
}

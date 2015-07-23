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
    public class EmployeeLocationController : ApiController
    {
        private readonly IEmployeeLocationService employeeLocationService;

        public EmployeeLocationController(IEmployeeLocationService employeeLocationService)
        {
            this.employeeLocationService = employeeLocationService;
        }

        [GET("location/employee/{id?}")]
        public HttpResponseMessage GetLocationByEmployeeId(int id)
        {
            var employeeLocation = employeeLocationService.GetLocationByEmployeeId(id);
            if (employeeLocation == null) return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee location not found");
            return Request.CreateResponse(HttpStatusCode.OK, employeeLocation);
        }

        [GET("employeelocation/create")]
        public void Post([FromBody] EmployeeLocationModel employeeLocationBusinessEntity)
        {
            employeeLocationService.CreateEmployeeLocation(employeeLocationBusinessEntity);
        }

    }
}

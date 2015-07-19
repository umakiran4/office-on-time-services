using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CabAgeBusinessEntities;
using CabAgeBusinessServices.Interfaces;
using AttributeRouting;
using AttributeRouting.Web.Http;

namespace CabAgeWebAPI.Controllers
{
    public class EmployeeSurveyController : ApiController
    {

        private readonly IEmployeeSurveyService employeeSurveyService;

        public EmployeeSurveyController(IEmployeeSurveyService employeeSurveyService)
        {
            this.employeeSurveyService = employeeSurveyService;
        }


        [GET("employeesurvey/employee/{id?}")]
        public HttpResponseMessage GetSurveyResultsOfAnEmployee(int id)
        {
            var employeeSurvey = employeeSurveyService.GetSurveyResultsOfAnEmployee(id);
            if (employeeSurvey == null) return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee Survey not found");
            return Request.CreateResponse(HttpStatusCode.OK, employeeSurvey);
        }

        [GET("employeesurvey/category/{id?}")]
        public HttpResponseMessage GetSurveyResultsBasedOnCategory(int id)
        {
            var employeeSurvey = employeeSurveyService.GetSurveyResultsBasedOnCategory(id);
            if (employeeSurvey == null) return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee Survey not found");
            return Request.CreateResponse(HttpStatusCode.OK, employeeSurvey);
        }

        [GET("employeesurvey/employee/{employeeid?}/category/{categoryid?}")]
        public HttpResponseMessage GetSurveyResultOfEmployeeBasedOnCategory(int employeeId, int categoryId)
        {
            var employeeSurvey = employeeSurveyService.GetSurveyResultOfEmployeeBasedOnCategory(employeeId, categoryId);
            if (employeeSurvey == null) return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee Survey not found");
            return Request.CreateResponse(HttpStatusCode.OK, employeeSurvey);
        }

        [POST("employeesurvey/create")]
        public void Post([FromBody] IList<EmployeeSurveyBusinessEntity> employeeSurveyBusinessEntity)
        {
            employeeSurveyService.CreateEmployeeSurvey(employeeSurveyBusinessEntity);
        }


        [AcceptVerbs("GET")]
        [GET("employeesurvey/iscomplete/employee/{id?}")]
        public HttpResponseMessage HasEmployeeCompletedTheSurvey(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, employeeSurveyService.HasEmployeeCompletedTheSurvey(id));
        }




    }
}

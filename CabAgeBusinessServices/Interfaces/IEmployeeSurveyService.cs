using CabAgeBusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabAgeBusinessServices.Interfaces
{
    public interface IEmployeeSurveyService
    {

        IEnumerable<EmployeeSurveyBusinessEntity> GetSurveyResultsOfAnEmployee(int employeeId);
        IEnumerable<EmployeeSurveyBusinessEntity> GetSurveyResultsBasedOnCategory(int categoryId);
        EmployeeSurveyBusinessEntity GetSurveyResultOfEmployeeBasedOnCategory(int employeeId, int categoryId);
        void CreateEmployeeSurvey(IList<EmployeeSurveyBusinessEntity> employeeSurvey);
        bool HasEmployeeCompletedTheSurvey(int employeeID);
    }
}

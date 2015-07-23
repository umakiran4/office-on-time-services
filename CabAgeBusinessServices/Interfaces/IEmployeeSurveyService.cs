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

        IEnumerable<EmployeeSurveyModel> GetSurveyResultsOfAnEmployee(int employeeId);
        IEnumerable<EmployeeSurveyModel> GetSurveyResultsBasedOnCategory(int categoryId);
        IEnumerable<EmployeeSurveyModel> GetSurveyResultOfEmployeeBasedOnCategory(int employeeId, int categoryId);
        void CreateEmployeeSurvey(IList<EmployeeSurveyModel> employeeSurvey);
        bool HasEmployeeCompletedTheSurvey(int employeeID);
    }
}

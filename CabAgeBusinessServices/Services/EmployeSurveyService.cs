using AutoMapper;
using CabAgeBusinessEntities;
using CabAgeBusinessServices.Interfaces;
using CabAgeDataModel;
using CabAgeDataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.Practices.Unity;
using CabAgeResolver;
 

namespace CabAgeBusinessServices.Services
{
    public class EmployeSurveyService : IEmployeeSurveyService
    {
        private readonly UnitOfWork unitOfWork;
        

        public EmployeSurveyService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public IEnumerable<EmployeeSurveyModel> GetSurveyResultsOfAnEmployee(int employeeId)
        {

            var employeeSurvey = unitOfWork.EmployeeSurveyRepository.GetBy(survey => survey.EmployeeID == employeeId);

            if (employeeSurvey == null) return null;

            Mapper.CreateMap<EmployeeSurveyResult,EmployeeSurveyModel>();
            Mapper.CreateMap<EmployeeMaster, EmployeeMasterModel>();
            Mapper.CreateMap<CategoryMaster, CategoryMasterModel>();
            var employeeSurveyModel = Mapper.Map<IEnumerable<EmployeeSurveyResult>,IEnumerable<EmployeeSurveyModel>>(employeeSurvey);

            return employeeSurveyModel;
        }

        public IEnumerable<EmployeeSurveyModel> GetSurveyResultsBasedOnCategory(int categoryId)
        {
               
            var employeeSurvey = unitOfWork.EmployeeSurveyRepository.GetBy(survey => survey.CategoryID == categoryId);

            if (employeeSurvey == null) return null;

            Mapper.CreateMap<EmployeeSurveyResult, EmployeeSurveyModel>();
            Mapper.CreateMap<EmployeeMaster, EmployeeMasterModel>();
            Mapper.CreateMap<CategoryMaster, CategoryMasterModel>();
            var employeeSurveyModel = Mapper.Map<IEnumerable<EmployeeSurveyResult>, IEnumerable<EmployeeSurveyModel>>(employeeSurvey);

            return employeeSurveyModel;
        }

        public IEnumerable<EmployeeSurveyModel> GetSurveyResultOfEmployeeBasedOnCategory(int employeeId, int categoryId)
        {

            var employeeSurvey = unitOfWork.EmployeeSurveyRepository.GetBy(survey => survey.EmployeeID == employeeId 
                                                                            && survey.CategoryID==categoryId);

            if (employeeSurvey == null) return null;

            Mapper.CreateMap<EmployeeSurveyResult, EmployeeSurveyModel>();
            Mapper.CreateMap<EmployeeMaster, EmployeeMasterModel>();
            Mapper.CreateMap<CategoryMaster, CategoryMasterModel>();
            var employeeSurveyModel = Mapper.Map<IEnumerable<EmployeeSurveyResult>, IEnumerable<EmployeeSurveyModel>>(employeeSurvey);

            return employeeSurveyModel;
        }


        public void CreateEmployeeSurvey(IList<EmployeeSurveyModel> employeeSurvey)
        {
            foreach (var surveyItem in employeeSurvey)
            {

                using (var scope = new TransactionScope())
                {
                    var employeeSurveyResult = new EmployeeSurveyResult
                    {
                        CategoryID = surveyItem.CategoryID,
                        EmployeeID = surveyItem.EmployeeID,
                        Rating = surveyItem.Rating,
                        CreatedDate = DateTime.Now
                    };
                    unitOfWork.EmployeeSurveyRepository.Insert(employeeSurveyResult);
                    unitOfWork.Save();
                    scope.Complete();

                }
            }
        }


        public bool HasEmployeeCompletedTheSurvey(int employeeID)
        {
            var categoryMasterService = Container.UnityContainer.Resolve<ICategoryMasterService>();
            var categories = categoryMasterService.GetAllCategories();
            int categoryCount=0;
            int employeeSurveyCategoryCount=0;

            if (categories != null && categories.Any())
            {
                categoryCount = categories.Count();
            }

            var employeeSurveyResults = GetSurveyResultsOfAnEmployee(employeeID);

            if (employeeSurveyResults != null && employeeSurveyResults.Any())
            {
                employeeSurveyCategoryCount = employeeSurveyResults.Count();
            }

            return categoryCount <= employeeSurveyCategoryCount;
        }

    }
}

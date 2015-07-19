using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using CabAgeBusinessServices.Interfaces;
using CabAgeBusinessServices.Services;
using CabAgeResolver;

namespace CabAgeBusinessServices
{
    [Export(typeof(IComponent))]
    public class DependencyResolver:IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<ICategoryMasterService,CategoryMasterService>();
            registerComponent.RegisterType<IEmployeeMasterService,EmployeeMasterService>();
            registerComponent.RegisterType<IEmployeeLocationService,EmployeeLocationService>();
            registerComponent.RegisterType<IEmployeeSurveyService, EmployeSurveyService>();
        }
    }
}

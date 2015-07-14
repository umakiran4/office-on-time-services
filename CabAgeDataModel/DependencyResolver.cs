using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using CabAgeDataModel.UnitOfWork;
using CabAgeResolver;

namespace CabAgeDataModel
{
     [Export(typeof(IComponent))]
        public class DependencyResolver : IComponent
        {
            public void SetUp(IRegisterComponent registerComponent)
            {
                registerComponent.RegisterType<IUnitOfWork, UnitOfWork.UnitOfWork>();
            }
        }
}

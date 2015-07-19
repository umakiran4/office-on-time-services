using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabAgeBusinessEntities;

namespace CabAgeBusinessServices.Interfaces
{
   public interface ICategoryMasterService
    {
        CategoryMasterBusinessEnitity GetCategoryById(int productId);
        IEnumerable<CategoryMasterBusinessEnitity> GetAllCategories();
    }
}

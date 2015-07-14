using System.Collections.Generic;
using System.Linq;
using CabAgeBusinessEntities;
using CabAgeBusinessServices.Interfaces;
using CabAgeDataModel.UnitOfWork;
using AutoMapper;
using CabAgeDataModel;

namespace CabAgeBusinessServices.Services
{
    public class CategoryMasterService : ICategoryMasterService

    {
        private readonly UnitOfWork unitOfWork;

        public CategoryMasterService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public CategoryMasterBusinessEnitity GetCategoryById(int categoryId)
        {
            var category = unitOfWork.CategoryMasterRepository.GetByID(categoryId);

            if (category == null) return null;
            Mapper.CreateMap<CategoryMaster, CategoryMasterBusinessEnitity>();
            var categoryModel = Mapper.Map<CategoryMaster,CategoryMasterBusinessEnitity>(category);
            return categoryModel;
        }

        public IEnumerable<CategoryMasterBusinessEnitity> GetAllCategories()
        {
            var categories = unitOfWork.CategoryMasterRepository.GetAll().ToList();

            if (!categories.Any()) return null;
            Mapper.CreateMap<CategoryMaster,CategoryMasterBusinessEnitity>();
            var categoriesModel = Mapper.Map<List<CategoryMaster>, List<CategoryMasterBusinessEnitity>>(categories);
            return categoriesModel;
        }

    }
}

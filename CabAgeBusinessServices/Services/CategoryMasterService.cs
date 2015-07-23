﻿using System.Collections.Generic;
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


        public CategoryMasterModel GetCategoryById(int id)
        {
            var category = unitOfWork.CategoryMasterRepository.GetByID(id);

            if (category == null) return null;

            Mapper.CreateMap<CategoryMaster, CategoryMasterModel>();
            var categoryModel = Mapper.Map<CategoryMaster,CategoryMasterModel>(category);

            return categoryModel;
        }


        public IEnumerable<CategoryMasterModel> GetAllCategories()
        {
            var categories = unitOfWork.CategoryMasterRepository.GetAll().ToList();

            if (!categories.Any()) return null;

            Mapper.CreateMap<CategoryMaster,CategoryMasterModel>();
            var categoriesModel = Mapper.Map<List<CategoryMaster>, List<CategoryMasterModel>>(categories);

            return categoriesModel;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CabAgeBusinessServices.Interfaces;
using CabAgeBusinessServices.Services;
using CabAgeBusinessEntities;
using AttributeRouting.Web.Http;


namespace CabAgeWebAPI.Controllers
{
    public class CategoryMasterController : ApiController
    {
        private readonly ICategoryMasterService categoryMasterService;

        public CategoryMasterController(ICategoryMasterService categoryMasterService)
        {
            this.categoryMasterService = categoryMasterService;
        }

        [GET("categories/getall")]
        public HttpResponseMessage GetAllCategories()
        {
            var categories = categoryMasterService.GetAllCategories();
            if (categories == null || !categories.Any()) return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Categories not found");
            var categoryEntities = categories as List<CategoryMasterBusinessEnitity> ?? categories.ToList();
            if (categoryEntities.Any())
                return Request.CreateResponse(HttpStatusCode.OK, categoryEntities);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Categories not found");
        }

        [GET("categories/category/{id?}")]
        public HttpResponseMessage GetCategoryById(int id)
        {
            var category = categoryMasterService.GetCategoryById(id);
            if (category == null) return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Category not found");
            return Request.CreateResponse(HttpStatusCode.OK, category);
        }


    }
}

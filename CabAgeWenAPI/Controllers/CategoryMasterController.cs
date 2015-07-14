using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CabAgeBusinessServices.Interfaces;
using CabAgeBusinessServices.Services;
using CabAgeBusinessEntities;


namespace CabAgeWebAPI.Controllers
{
    public class CategoryMasterController : ApiController
    {
        private readonly ICategoryMasterService categoryMasterService;

        public CategoryMasterController(ICategoryMasterService categoryMasterService)
        {
            this.categoryMasterService = categoryMasterService;
        }


        public HttpResponseMessage Get()
        {
            var categories = categoryMasterService.GetAllCategories();
            if (categories == null || !categories.Any()) return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Categories not found");
            var categoryEntities = categories as List<CategoryMasterBusinessEnitity> ?? categories.ToList();
            if (categoryEntities.Any())
                return Request.CreateResponse(HttpStatusCode.OK, categoryEntities);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Categories not found");
        }

    }
}

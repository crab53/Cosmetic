using Cosmetic.Bussiness.Bussiness;
using Cosmetic.Bussiness.Requests;
using Cosmetic.Core.Request;
using Cosmetic.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace CosmeticAPI.Controllers
{
    public class CategoryController : ApiController
    {
        // POST: Create or Update Category
        [HttpPost, Route(ApiRoutes.Category_CreateUpdate)]
        public async Task<CosApiResponse> CreateUpdateCategory(CategoryRequests request)
        {
            NSLog.Logger.Info("CreateUpdateCategory", request);
            return await CosBusCategory.Instance.CreateUpdateCategory(request);
        }
        // Delete Category
        [HttpPost, Route(ApiRoutes.Category_Delete)]
        public async Task<CosApiResponse> DeleteCategory(RequestModelBase request)
        {
            NSLog.Logger.Info("DeleteCategory", request);
            return await CosBusCategory.Instance.DeleteCatgory(request);
        }
        // Get Detail Category
        [HttpPost, Route(ApiRoutes.Category_Get_ID)]
        public async Task<CosApiResponse> GetDetailCategory(RequestModelBase request)
        {
            NSLog.Logger.Info("Get Detail Category", request);
            return await CosBusCategory.Instance.GetDetailCategory(request);
        }
        // Get List Category
        [HttpPost, Route(ApiRoutes.Category_Get_List)]
        public async Task<CosApiResponse> GetListCategory(RequestModelBase request)
        {
            NSLog.Logger.Info("Get List Category", request);
            return await CosBusCategory.Instance.GetListCategory(request);
        }
    }
}
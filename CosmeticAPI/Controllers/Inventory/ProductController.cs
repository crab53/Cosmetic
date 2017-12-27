using Cosmetic.Bussiness.DTO;
using Cosmetic.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Cosmetic.Bussiness.Bussiness;
using Cosmetic.Core.Request;
using Cosmetic.Bussiness.Requests;

namespace CosmeticAPI.Controllers.Inventory
{
    public class ProductController : ApiController
    {
        [HttpPost, Route(ApiRoutes.Product_CreateUpdate)]
        public async Task<CosApiResponse> CreateUpdateProduct(CreateUpdateProductRequest request)
        {
            NSLog.Logger.Info("CreateUpdateProduct", request);
            return await CosBusProduct.Instance.CreateUpdateProduct(request);
        }

        [HttpPost, Route(ApiRoutes.Product_Delete)]
        public async Task<CosApiResponse> DeleteProduct(RequestModelBase request)
        {
            NSLog.Logger.Info("DeleteProduct", request);
            return await CosBusProduct.Instance.DeleteProduct(request);
        }

        [HttpPost, Route(ApiRoutes.Product_Get_ID)]
        public async Task<CosApiResponse> GetIDProduct(RequestModelBase request)
        {
            NSLog.Logger.Info("GetIDProduct", request);
            return await CosBusProduct.Instance.GetIDProduct(request);
        }

        [HttpPost, Route(ApiRoutes.Product_Get_List)]
        public async Task<CosApiResponse> GetListProduct(RequestModelBase request)
        {
            NSLog.Logger.Info("GetListProduct", request);
            return await CosBusProduct.Instance.GetListProduct(request);
        }
    }
}

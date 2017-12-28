using Cosmetic.Bussiness.Bussiness;
using Cosmetic.Bussiness.Requests;
using Cosmetic.Core.Request;
using Cosmetic.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CosmeticAPI.Controllers
{
    public class PriceController : ApiController
    {
        [HttpPost, Route(ApiRoutes.Price_CreateUpdate)]
        public async Task<CosApiResponse> CreateUpdatePrice(PriceRequest request)
        {
            NSLog.Logger.Info("CreateUpdatePrice", request);
            return await CosBusPrice.Instance.CreateUpdatePrice(request);
        }

        [HttpPost, Route(ApiRoutes.Price_Delete)]
        public async Task<CosApiResponse> DeletePrice(RequestModelBase request)
        {
            NSLog.Logger.Info("DeletePrice", request);
            return await CosBusPrice.Instance.DeletePrice(request);
        }

        [HttpPost, Route(ApiRoutes.Price_Get_ID)]
        public async Task<CosApiResponse> GetDetailPrice(RequestModelBase request)
        {
            NSLog.Logger.Info("GetIDPrice", request);
            return await CosBusPrice.Instance.GetDetailPrice(request);
        }

        [HttpPost, Route(ApiRoutes.Price_Get_List)]
        public async Task<CosApiResponse> GetListPrice(RequestModelBase request)
        {
            NSLog.Logger.Info("GetListPrice", request);
            return await CosBusPrice.Instance.GetListPrice(request);
        }
    }
}
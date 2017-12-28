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
    public class OrderController : ApiController
    {
        [HttpPost, Route(ApiRoutes.Order_CreateUpdate)]
        public async Task<CosApiResponse> CreateUpdateOrder(OrderRequest request)
        {
            NSLog.Logger.Info("CreateUpdateOrder", request);
            return await CosBusOrder.Instance.CreateUpdateOrder(request);
        }

        [HttpPost, Route(ApiRoutes.Order_Delete)]
        public async Task<CosApiResponse> DeleteOrder(RequestModelBase request)
        {
            NSLog.Logger.Info("DeleteOrder", request);
            return await CosBusOrder.Instance.DeleteOrder(request);
        }

        [HttpPost, Route(ApiRoutes.Product_Get_ID)]
        public async Task<CosApiResponse> GetIDProduct(RequestModelBase request)
        {
            NSLog.Logger.Info("GetDetailOrder", request);
            return await CosBusOrder.Instance.GetDetailOrder(request);
        }

        [HttpPost, Route(ApiRoutes.Product_Get_List)]
        public async Task<CosApiResponse> GetListProduct(RequestModelBase request)
        {
            NSLog.Logger.Info("GetListOrder", request);
            return await CosBusOrder.Instance.GetListOrder(request);
        }
    }
}
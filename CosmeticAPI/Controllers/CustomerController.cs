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
    public class CustomerController : ApiController
    {
        [HttpPost, Route(ApiRoutes.Customer_CreateUpdate)]
        public async Task<CosApiResponse> CreateUpdateProduct(CustomerRequest request)
        {
            NSLog.Logger.Info("CreateUpdateCustomer", request);
            return await CosBusCustomer.Instance.CreateUpdateCustomer(request);
        }

        [HttpPost, Route(ApiRoutes.Customer_Delete)]
        public async Task<CosApiResponse> DeleteProduct(RequestModelBase request)
        {
            NSLog.Logger.Info("DeleteCustomer", request);
            return await CosBusCustomer.Instance.DeleteCustomer(request);
        }

        [HttpPost, Route(ApiRoutes.Customer_Get_ID)]
        public async Task<CosApiResponse> GetIDProduct(RequestModelBase request)
        {
            NSLog.Logger.Info("GetIDCustomer", request);
            return await CosBusCustomer.Instance.GetDetailCustomer(request);
        }

        [HttpPost, Route(ApiRoutes.Customer_Get_List)]
        public async Task<CosApiResponse> GetListProduct(RequestModelBase request)
        {
            NSLog.Logger.Info("GetListCustomer", request);
            return await CosBusCustomer.Instance.GetListCustomer(request);
        }
    }
}
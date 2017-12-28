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
    public class RoleController : ApiController
    {
        [HttpPost, Route(ApiRoutes.Role_CreateUpdate)]
        public async Task<CosApiResponse> CreateUpdateRole(RoleRequest request)
        {
            NSLog.Logger.Info("CreateUpdateRole", request);
            return await CosBusRole.Instance.CreateUpdateRole(request);
        }

        [HttpPost, Route(ApiRoutes.Role_Delete)]
        public async Task<CosApiResponse> DeleteRole(RequestModelBase request)
        {
            NSLog.Logger.Info("DeleteRole", request);
            return await CosBusRole.Instance.DeleteRole(request);
        }

        [HttpPost, Route(ApiRoutes.Role_Get_ID)]
        public async Task<CosApiResponse> GetIDRole(RequestModelBase request)
        {
            NSLog.Logger.Info("GetIDRole", request);
            return await CosBusRole.Instance.GetDetailRole(request);
        }

        [HttpPost, Route(ApiRoutes.Role_Get_List)]
        public async Task<CosApiResponse> GetListRole(RequestModelBase request)
        {
            NSLog.Logger.Info("GetListRole", request);
            return await CosBusRole.Instance.GetListRole(request);
        }
    }
}
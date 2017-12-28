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
    public class UserController : ApiController
    {
        [HttpPost, Route(ApiRoutes.User_CreateUpdate)]
        public async Task<CosApiResponse> CreateUpdateUser(UserRequest request)
        {
            NSLog.Logger.Info("CreateUpdateUser", request);
            return await CosBusUser.Instance.CreateUpdateUser(request);
        }

        [HttpPost, Route(ApiRoutes.User_Delete)]
        public async Task<CosApiResponse> DeleteUser(RequestModelBase request)
        {
            NSLog.Logger.Info("DeleteUser", request);
            return await CosBusUser.Instance.DeleteUser(request);
        }

        [HttpPost, Route(ApiRoutes.User_Get_ID)]
        public async Task<CosApiResponse> GetIDUser(RequestModelBase request)
        {
            NSLog.Logger.Info("GetIDUser", request);
            return await CosBusUser.Instance.GetDetailUser(request);
        }

        [HttpPost, Route(ApiRoutes.User_Get_List)]
        public async Task<CosApiResponse> GetListUser(RequestModelBase request)
        {
            NSLog.Logger.Info("GetListUser", request);
            return await CosBusUser.Instance.GetListUser(request);
        }
    }
}
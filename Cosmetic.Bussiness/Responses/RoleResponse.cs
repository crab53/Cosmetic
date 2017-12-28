using Cosmetic.Bussiness.DTO;
using Cosmetic.Core.Response;
using Cosmetic.DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.Bussiness.Responses
{
    public class GetDetailRoleResponse : CosApiResponseBase
    {
        public RoleDTO Role { get; set; }
    }
    public class GetListRoleResponse : CosApiResponseBase
    {
        public List<RoleDTO> ListRole { get; set; }
    }
}

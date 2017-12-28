using Cosmetic.Bussiness.DTO;
using Cosmetic.Core.Response;
using System.Collections.Generic;

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

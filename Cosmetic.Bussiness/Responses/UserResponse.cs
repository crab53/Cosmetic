using Cosmetic.Bussiness.DTO;
using Cosmetic.Core.Response;
using System.Collections.Generic;

namespace Cosmetic.Bussiness.Responses
{
    public class GetDetailUserResponse : CosApiResponseBase
    {
        public UserDTO User { get; set; }
    }
    public class GetListUserResponse : CosApiResponseBase
    {
        public List<UserDTO> ListUser { get; set; }
    }
}

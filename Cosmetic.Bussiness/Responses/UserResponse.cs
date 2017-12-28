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
    public class GetDetailUserResponse : CosApiResponseBase
    {
        public UserDTO User { get; set; }
    }
    public class GetListUserResponse : CosApiResponseBase
    {
        public List<UserDTO> ListUser { get; set; }
    }
}

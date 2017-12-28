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
    public class GetDetailOrderResponse : CosApiResponseBase
    {
        public OrderDTO Order { get; set; }
    }
    public class GetListOrderResponse : CosApiResponseBase
    {
        public List<OrderDTO> ListOrder { get; set; }
        public GetListOrderResponse()
        {
            ListOrder = new List<OrderDTO>();
        }
    }
}

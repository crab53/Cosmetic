using Cosmetic.Bussiness.DTO;
using Cosmetic.Core.Response;
using System.Collections.Generic;

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

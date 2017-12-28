using Cosmetic.Bussiness.DTO;
using Cosmetic.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.Bussiness.Responses
{
    public class GetDetailCustomerResponse : CosApiResponseBase
    {
        public CustomersDTO Customer { get; set; }
    }
    public class GetListCustomerResponse : CosApiResponseBase
    {
        public List<CustomersDTO> ListCustomer { get; set; }
        public GetListCustomerResponse()
        {
            ListCustomer = new List<CustomersDTO>();
        }
    }
}

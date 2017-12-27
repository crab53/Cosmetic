using Cosmetic.Bussiness.DTO;
using Cosmetic.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.Bussiness.Responses
{
    public class GetIDProductResponse: CosApiResponseBase
    {
        public ProductDTO Pro { get; set; }
    }

    public class GetListProductResponse: CosApiResponseBase
    {
        public List<ProductDTO> ListProd { get; set; }
        public GetListProductResponse()
        {
            ListProd = new List<ProductDTO>();
        }
    }
}

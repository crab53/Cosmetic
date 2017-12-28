using Cosmetic.Bussiness.DTO;
using Cosmetic.Core.Response;
using System.Collections.Generic;

namespace Cosmetic.Bussiness.Responses
{
    public class GetDetailPriceResponse: CosApiResponseBase
    {
        public PriceDTO Price { get; set; }
    }
    public class GetListPriceResponse : CosApiResponseBase
    {
        public List<PriceDTO> ListPrice { get; set; }
    }
}

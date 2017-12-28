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
   public class GetDetailPriceResponse: CosApiResponseBase
    {
        public PriceDTO Price { get; set; }
    }
    public class GetListPriceResponse : CosApiResponseBase
    {
        public List<PriceDTO> ListPrice { get; set; }
    }
}

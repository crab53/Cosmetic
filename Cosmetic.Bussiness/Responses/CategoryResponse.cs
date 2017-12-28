using Cosmetic.Bussiness.DTO;
using Cosmetic.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.Bussiness.Responses
{
   public class GetListCategoryResponse : CosApiResponseBase
    {
        public List<CategoryDTO> ListCate { get; set; }
        public GetListCategoryResponse()
        {
            ListCate = new List<CategoryDTO>();
        }
    }
    public class GetIDCategoryResponse :CosApiResponse
    {
        public CategoryDTO Cate { get; set; }
    }
}

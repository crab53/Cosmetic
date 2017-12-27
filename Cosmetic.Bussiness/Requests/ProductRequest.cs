using Cosmetic.Bussiness.DTO;
using Cosmetic.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.Bussiness.Requests
{
    public class CreateUpdateProductRequest : RequestModelBase
    {
        public ProductDTO Pro { get; set; }
    }
}

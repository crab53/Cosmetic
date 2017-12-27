using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetic.Core.Request;

namespace Cosmetic.Bussiness.DTO
{
    public class ProductDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string CateID { get; set; }
    }
}

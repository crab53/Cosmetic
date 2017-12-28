using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.Bussiness.DTO
{
   public class OrderDTO: BaseDTO
    {
        public string OrderNo { get; set; }
        public string ReceiptNo { get; set; }
        public string CustomerId { get; set; }
        public int TotalBil { get; set; }
        public int? Discount { get; set; }
        
    }
}

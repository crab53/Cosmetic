using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.DataModel.Entities
{
    public class Order : BaseEntities
    {
        public string OrderNo { get; set; }
        public string ReceiptNo { get; set; }
        public string CustomerId { get; set; }
        public int TotalBil { get; set; }
        public int? Discount { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.DataModel.Entities
{
   public class Product: BaseEntities
    {
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public decimal Price { get; set; }        
        public virtual Category Categories { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

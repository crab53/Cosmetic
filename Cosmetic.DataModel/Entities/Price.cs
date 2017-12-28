using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.DataModel.Entities
{
   public class Price: BaseEntities
    {
        public decimal Prices { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
        public string ProductId { get; set; }
        public virtual Product Products { get; set; }
    }
}

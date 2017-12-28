using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.DataModel.Entities
{
    public class Category:BaseEntities
    {
        
        public string Name { get; set; }
        public string ParentId { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

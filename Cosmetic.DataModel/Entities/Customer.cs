using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.DataModel.Entities
{
   public class Customer: BaseEntities
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool Active { get; set;
        }
    }
}
